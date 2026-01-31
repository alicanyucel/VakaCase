using VakaCase.Application.Features.Auth.Login;
using VakaCase.Domain.Entities;

namespace VakaCase.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
