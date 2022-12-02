using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Security.Claims;
using UniLibrary.Models.Enums;

namespace UniLibrary.Controllers
{
#nullable disable

    public class UsersController : Controller
    {
        public readonly IUserService _userService;
        public readonly ILoanService _loanService;

        public UsersController(IUserService userService, ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync(orderBy: m => m.OrderBy(m => m.Name), includeProperties: m => m.Loans);
            return View(users);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken, AllowAnonymous]
        public async Task<ActionResult> Create(RegisterViewModel registerViewModel, string status)
        {
            var userInDb = await _userService.GetAllAsync();
            foreach (var item in userInDb)
            {
                if (registerViewModel.StudentID.ToLower().Trim() != item.StudentID.ToLower().Trim() && registerViewModel.Name.ToLower().Trim() != item.Name.ToLower().Trim())
                {
                    try
                    {
                        var userType = UserType.Admin;
                        switch (registerViewModel.UserType)
                        {
                            case "Admin":
                                userType = UserType.Admin;
                                break;
                            case "PostGraduate":
                                userType = UserType.PostGraduate;
                                break;
                            case "UnderGraduate":
                                userType = UserType.UnderGraduate;
                                break;
                        }
                        User user = new()
                        {
                            StudentID = registerViewModel.StudentID,
                            Name = registerViewModel.Name,
                            Password = BCrypt.Net.BCrypt.HashPassword(registerViewModel.Password),
                            Type = userType
                        };
                        await _userService.AddAsync(user);
                        TempData["Success"] = "Member Created Successfully";
                        if (status.Equals("Login"))
                        {
                            await LoginUser(registerViewModel.StudentID, registerViewModel.Password, "");
                            return RedirectToAction("Index", "Home");
                        }
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbException)
                    {
                        TempData["Error"] = "Something Went Wrong. Try Again Later.";
                        return View();
                    }
                }
                else
                {
                    TempData["Error"] = "Member Already Exists";
                    return View();
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginUser(string studentID, string password, string returnURL)
        {
            var loginValid = ValidateLogin(studentID, password);
            if (!loginValid.Result)
            {
                TempData["LoginFailed"] = $"The username or password is incorrect";
                return Redirect("/login");
            }
            else
            {
                await SignInUser(studentID);
                if (string.IsNullOrWhiteSpace(returnURL) || !returnURL.StartsWith("/"))
                {
                    TempData["Success"] = $"Login Success";
                    returnURL = "/";
                }
                return this.Redirect(returnURL);
            }
        }

        private async Task<bool> ValidateLogin(string studentID, string password)
        {
            var userInDb = await _userService.GetAllAsync();
            foreach (var item in userInDb)
            {
                if (studentID.ToLower().Trim() == item.StudentID.ToLower().Trim())
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(password, item.Password);
                    return verified;
                }
            }
            return false;
        }

        private async Task SignInUser(string studentID)
        {
            var user = await _userService.GetAllAsync();
            foreach (var item in user)
            {
                if (item.StudentID == studentID)
                {
                    TempData["UserID"] = item.ID;
                    TempData["UserName"] = item.Name;
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,studentID),
                        new Claim("AllRegisteredUsers","true")
                    };
                    if (item.Type == UserType.Admin)
                        claims.Add(new Claim("Admin", "true"));
                    else if (item.Type == UserType.PostGraduate)
                        claims.Add(new Claim("PostGraduate", "true"));
                    else
                        claims.Add(new Claim("UnderGraduate", "true"));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                }
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByIdAsync(id, includeProperties: true);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int id, [Bind("ID,StudentID,Name")] User user)
        {
            if (id != user.ID)
            {
                return NotFound();
            }
            try
            {
                await _userService.UpdateAsync(user);
                TempData["Success"] = "User updated Successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await UserExists(user.ID))
                {
                    return NotFound();
                }
                else
                {
                    TempData["Error"] = "An Unexpected Error Occured!";
                }
            }
            return View(user);
        }

        public async Task<bool> UserExists(int id)
        {
            return await _userService.GetByIDAsync(id) != null;
        }

        [HttpDelete, Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var userInDb = await _userService.GetByIDAsync(id);
            var loanInDb = _loanService.GetLoanOrDefault(filter: b => b.UserID == userInDb.ID);
            if (loanInDb != null)
            {
                return Json(new { error = true, message = "You cannot delete this User as long as it has loans referring to it!" });
            }
            await _userService.DeleteAsync(id);
            return Json(new { success = true, message = "User Deleted Successfully." });
        }

    }
}