using UniLibrary.Interfaces;
using UniLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Security.Cryptography;

namespace UniLibrary.Controllers
{
#nullable disable
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public readonly ILoanService _loanService;

        public UserController(IUserService userService, ILoanService loanService)
        {
            _userService = userService;
            _loanService = loanService;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync(orderBy: m => m.OrderBy(m => m.Name), includeProperties: m => m.Loans);
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(User user)
        {
            var userInDb = await _userService.GetAllAsync();
            foreach (var item in userInDb)
            {
                if (user.StudentID.ToLower().Trim() != item.StudentID.ToLower().Trim() && user.Name.ToLower().Trim() != item.Name.ToLower().Trim())
                {
                    try
                    {
                        await _userService.AddAsync(user);
                        TempData["Success"] = "Member Created Successfully";
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

    }
}