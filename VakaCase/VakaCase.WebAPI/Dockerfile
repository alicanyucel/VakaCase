


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["VakaCase.WebAPI.csproj", "./"]
RUN dotnet restore "VakaCase.WebAPI.csproj"
COPY . .
RUN dotnet publish "VakaCase.WebAPI.csproj" -c Release -o /app/publish /p:PublishTrimmed=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "VakaCase.WebAPI.dll"]