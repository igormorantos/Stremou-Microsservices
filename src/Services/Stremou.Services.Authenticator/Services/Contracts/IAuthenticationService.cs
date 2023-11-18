using Microsoft.AspNetCore.Identity;
using Stremou.Domain.Models;

namespace Stremou.Services.Authenticator.Services.Contracts
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterAsync(User email, User password);
        Task<SignInResult> LoginAsync(User email, User password);
        Task LogoutAsync();
    }
}
