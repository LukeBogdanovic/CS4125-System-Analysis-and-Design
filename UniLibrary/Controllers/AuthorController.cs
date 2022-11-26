using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using UniLibrary.Interfaces;
using UniLibrary.Models;

namespace UniLibrary.Controllers
{
#nullable disable
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;

        public AuthorsController(IAuthorService authorService, IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync(includeProperties: a => a.Books);
            return View(authors);
        }

        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Author author)
        {
            try
            {
                await _authorService.AddAsync(author);// Adding author to the database
                TempData["Success"] = "Author created Successfully.";
                return RedirectToAction(nameof(Index)); // Redirect from the create page to the Index of the Authors controller
            }
            catch (DbException)
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] Author author)
        {
            if (id != author.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _authorService.UpdateAsync(author);
                    TempData["Success"] = "Author Updated Successfully.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await AuthorExists(author.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["Error"] = "An Unexpected Error Occured!";
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }
        // Check for if an author already exists in the database
        private async Task<bool> AuthorExists(int id)
        {
            return await _authorService.GetByIDAsync(id) != null;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync(includeProperties: a => a.Books);
            return Json(new { data = authors });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var authorInDb = await _authorService.GetByIDAsync(id);
            var bookInDb = await _bookService.GetBookOrDefaultAsync(filter: b => b.Author.ID == authorInDb.ID);
            if (bookInDb != null)
            {
                return Json(new { error = true, message = "You cannot delete this author while there are books referring to it" });
            }
            await _authorService.DeleteAsync(id);
            return Json(new { success = true, message = "Author Deleted Successfully." });
        }

    }
}