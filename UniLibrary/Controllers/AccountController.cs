using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using UniLibrary.Models;
using System.Security.Claims;

namespace UniLibrary.Controllers
{
    public class AccountController : Controller
    {
        public async Task Login(string returnURL = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder().WithRedirectUri(returnURL).Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View(new User()
            {
                Name = User.Identity.Name,
                Email = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value,
                Avatar = User.FindFirst(c => c.Type == "picture")?.Value
            });
        }

        [Authorize]
        public async Task Logout()
        {
            var authenticationProperties = new LogoutAuthenticationPropertiesBuilder().WithRedirectUri("/Home/Index").Build();
            await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}