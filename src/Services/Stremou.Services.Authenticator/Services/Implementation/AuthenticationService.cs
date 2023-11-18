using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Stremou.Domain.Models;
using Stremou.Modules.Domain.ValueObjects;
using System.Security.Claims;

namespace Stremou.Services.Authenticator.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthenticationService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> RegisterAsync(string name, string email, string password, Cpf cpf)
        {
            var user = new User (name, email, password, cpf);
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, isPersistent: false, lockoutOnFailure: false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
 
        public Task<AuthenticateResult> AuthenticateAsync(HttpContext context, string? scheme)
        {
            throw new NotImplementedException();
        }

        public Task ChallengeAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }

        public Task ForbidAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(HttpContext context, string? scheme, ClaimsPrincipal principal, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(HttpContext context, string? scheme, AuthenticationProperties? properties)
        {
            throw new NotImplementedException();
        }
    }
}
