using UniLibrary.Models.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.Common;
using UniLibrary.Interfaces;
using UniLibrary.ViewModels;
using UniLibrary.Models;

namespace UniLibrary.Controllers
{
#pragma warning disable
    [Authorize(Policy = "Admin")]
    public class LoansController : Controller
    {
        private readonly ILoanService _loanService;
        private readonly IBookCopyLoanService _bookCopyLoanService;
        private readonly IBookCopyService _bookCopyService;
        private readonly IUserService _userService;

        public LoansController(ILoanService loanService, IBookCopyLoanService bookCopyLoanService, IBookCopyService bookCopyService, IUserService userService)
        {
            _loanService = loanService;
            _bookCopyLoanService = bookCopyLoanService;
            _bookCopyService = bookCopyService;
            _userService = userService;
        }

        public async Task<IActionResult> Index(string status)
        {
            LoanViewModel model = new()
            {
                Loan = new(),
                Loans = null,
                BookCopies = await _bookCopyService.GetAllBookCopiesAsync(filter: null, orderBy: null, b => b.Details, b => b.BookCopyLoans),
                BookCopyLoans = null
            };
            switch (status)
            {
                case "isActive":
                    model.Loans = await _loanService.GetAllLoansAsync(filter: x => x.ReturnDate == DateTime.MinValue, orderBy: null, l => l.User, l => l.BookCopyLoans);
                    break;
                default:
                    model.Loans = await _loanService.GetAllLoansAsync(filter: null, orderBy: x => x.OrderByDescending(l => l.LoanID), l => l.User, l => l.BookCopyLoans);
                    break;
            }
            foreach (var loan in model.Loans)
            {
                model.Loan = _loanService.GetLoanOrDefault(x => x.LoanID == loan.LoanID, includeProperties: "BookCopyLoans");
                model.BookCopyLoans = await _bookCopyLoanService.GetAllBookCopyLoansAsync(filter: l => (l.LoanID == loan.LoanID), orderBy: null, b => b.Loan, b => b.BookCopy);
                if (model.Loan.ReturnDate == DateTime.MinValue)
                {
                    model.Loan.setFee(model.BookCopyLoans.Count);
                }
            }
            model.BookCopies = await _bookCopyService.GetAllBookCopiesAsync(filter: null, orderBy: null, b => b.Details, b => b.BookCopyLoans);
            return View(model);
        }
        [Authorize(Roles = "Admin,PostGraduate,UnderGraduate")]
        public async Task<IActionResult> Create()
        {
            IEnumerable<BookCopy> bookCopies = await _bookCopyService.GetAllBookCopiesAsync(filter: x => x.IsAvailable == true, orderBy: x => x.OrderBy(x => x.Details.Title), b => b.Details, b => b.BookCopyLoans);
            IEnumerable<User> users = await _userService.GetAllAsync();
            LoanViewModel model = new()
            {
                Copies = null,
                Users = users.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.ID.ToString()
                })
            };
            for (var i = 0; i < LoanStatus.Max; i++)
            {
                model.Copies = bookCopies.Select(i => new SelectListItem
                {
                    Text = i.Details.Title.ToString(),
                    Value = i.BookCopyID.ToString()
                }).Distinct(new SelectListComparer());
            }
            return View(model);
        }

        public async Task<IActionResult> Return(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            try
            {
                IReadOnlyList<BookCopyLoan> bookCopyLoans = await _bookCopyLoanService.GetAllBookCopyLoansAsync(x => x.LoanID == id);
                foreach (var bookCopy in bookCopyLoans)
                {
                    BookCopy copy = await _bookCopyService.GetByIDAsync(bookCopy.BookCopyID);
                    copy.IsAvailable = true;
                    await _bookCopyService.UpdateAsync(copy);
                }
                Loan loanToBeUpdated = await _loanService.GetByIDAsync(id);
                loanToBeUpdated.Fee = loanToBeUpdated.setFee(bookCopyLoans.Count);
                loanToBeUpdated.setReturnDate();
                await _loanService.UpdateAsync(loanToBeUpdated);
                TempData["Success"] = "Books Returned Succesfully";
                return RedirectToAction(nameof(Index));
            }
            catch (DbException)
            {
                TempData["Error"] = "Something Went Wrong.";
                return View();
            }
        }

        #region API CALLS
        [HttpPost, Authorize(Policy = "Admin,PostGraduate,UnderGraduate")]
        public async Task<IActionResult> Create(LoanViewModel model, int id, int[] ids)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id, includeProperties: true);
                model.User = user;
                IEnumerable<BookCopy> bookCopies = await _bookCopyService.GetAllBookCopiesAsync(filter: b => b.IsAvailable == true, orderBy: null, b => b.Details, b => b.BookCopyLoans);
                int borrowedCopies = 0;
                if (user.Loans != null)
                {
                    foreach (var loan in user.Loans)
                    {
                        if (loan.ReturnDate == DateTime.MinValue)
                        {
                            IEnumerable<BookCopyLoan> bookCopyLoans = loan.BookCopyLoans.Where(l => l.LoanID == loan.LoanID);
                            if (bookCopyLoans != null)
                            {
                                borrowedCopies += bookCopyLoans.Count();
                            }
                        }
                    }
                }
                int bookCopiesToBorrow = 0;
                foreach (var loan in user.Loans)
                {
                    var bookCopyLoans = loan.BookCopyLoans.Where(l => l.LoanID == loan.LoanID).Select(x => x.BookCopy.Details.Title).Count();
                    if (bookCopyLoans != null)
                    {
                        bookCopiesToBorrow += bookCopyLoans;
                    }
                }
                var totalBookCount = borrowedCopies + bookCopiesToBorrow;
                if (totalBookCount <= BookStatus.Max)
                {
                    if (model.Loan == null)
                    {
                        model.Loan = new Loan()
                        {
                            UserID = id
                        };
                        await _loanService.AddAsync(model.Loan);
                        var loanInDb = await _loanService.GetByIDAsync(model.Loan.LoanID);
                        for (var i = 0; i < ids.Length; i++)
                        {
                            BookCopyLoan bookCopyLoan = new()
                            {
                                LoanID = loanInDb.LoanID,
                                BookCopyID = ids[i]
                            };
                            await _bookCopyLoanService.AddAsync(bookCopyLoan);
                            var bookCopy = await _bookCopyService.GetBookCopyOrDefaultAsync(x => x.BookCopyID == bookCopyLoan.BookCopyID, "Details");
                            bookCopy.IsAvailable = false;
                            await _bookCopyService.UpdateAsync(bookCopy);
                        }
                    }
                    return Json(new { success = true, message = "Loan Created Succesfully." });
                }
                else
                {
                    return Json(new { error = true, message = "You Have Exceeded the Allowed Number of Borrowed Books." });
                }
            }
            catch (DbException)
            {
                return Json(new { error = true, message = "Something Went Wrong!" });
            }
            return Json(new { error = true, message = "An Unexpected Error Occured!" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                try
                {
                    IReadOnlyList<BookCopyLoan> bookCopyLoans = await _bookCopyLoanService.GetAllBookCopyLoansAsync(x => x.LoanID == id);
                    foreach (var bookCopy in bookCopyLoans)
                    {
                        BookCopy copy = await _bookCopyService.GetByIDAsync(bookCopy.BookCopyID);
                        copy.IsAvailable = true;
                        await _bookCopyService.UpdateAsync(copy);
                    }
                    _bookCopyLoanService.RemoveRange(bookCopyLoans);
                    await _loanService.DeleteAsync(id);
                    return Json(new { success = true, message = "Loan Deleted Succesfully." });
                }
                catch (DbException)
                {
                    return Json(new { error = true, message = "Something Went Wrong." });
                }
            }
            return Json(new { error = true, message = "An Unexpected Error Occured." });
        }
        #endregion
    }
}