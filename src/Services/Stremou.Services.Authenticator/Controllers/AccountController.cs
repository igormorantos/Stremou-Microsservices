using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stremou.Domain.Models;
using Stremou.Services.Authenticator.Models;

namespace Stremou.Services.Authenticator.Controllers
{

        [ApiController]
        [Route("[controller]")]
        public class AccountController : ControllerBase
        {
            private readonly IAuthenticationService _authenticationService;

            public AccountController(IAuthenticationService authenticationService)
            {
                _authenticationService = authenticationService;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterModel model)
            {
                var result = await _authenticationService.RegisterAsync(model.Name, model.Cpf, model.Email, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return BadRequest(result.Errors);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginModel model)
            {
                var result = await _authenticationService.LoginAsync(model.Email, model.Password);

                if (result.Succeeded)
                {
                    return Ok();
                }

                return Unauthorized();
            }

            [HttpPost("logout")]
            public async Task<IActionResult> Logout()
            {
                await _authenticationService.LogoutAsync();
                return Ok();
            }
        }

        // Services/IAuthenticationService.cs
        public interface IAuthenticationService
        {
            Task<IdentityResult> RegisterAsync(User name, User cpf, User email, User password);
            Task<Microsoft.AspNetCore.Identity.SignInResult> LoginAsync(User email, User password);
            Task LogoutAsync();
        }

}
