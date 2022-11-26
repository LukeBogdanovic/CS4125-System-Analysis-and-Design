using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Auth0.AspNetCore.Authentication;
using UniLibrary.Models;
using System.Security.Claims;

namespace UniLibrary.Controllers
{
    public class AccountController : Controller
    {
        /*
        Login using Auth0 
        */
        public async Task Login(string returnURL = "/")
        {
            var authenticationProperties = new LoginAuthenticationPropertiesBuilder().WithRedirectUri(returnURL).Build();
            await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
        }

        /*
        Logout using Auth0.
        User must be logged in to use this function.
        */
        [Authorize]
        public IActionResult Profile()
        {
            return View(new User()
            {
                Name = User.Identity!.Name!,
                EmailAddress = User.FindFirst(c => c.Type == ClaimTypes.Email)?.Value!,
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