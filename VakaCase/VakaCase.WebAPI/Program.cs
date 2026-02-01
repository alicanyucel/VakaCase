using DefaultCorsPolicyNugetPackage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using VakaCase.Application;
using VakaCase.Application.Abstractions;
using VakaCase.Infrastructure;
using VakaCase.WebAPI.Hubs;
using VakaCase.WebAPI.Middlewares;
using VakaCase.WebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultCors();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddExceptionHandler<ExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddScoped<IDeviceNotifier, SignalRDeviceNotifier>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecuritySheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** yourt JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecuritySheme, Array.Empty<string>() }
                });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseExceptionHandler();

app.MapControllers();
app.MapHub<DeviceHub>("/hubs/devices");
app.MapHub<DeviceHub>("/deviceHub");

ExtensionsMiddleware.CreateFirstUser(app);

app.Run();
