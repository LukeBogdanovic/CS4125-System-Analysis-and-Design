using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniLibrary.Models;
using UniLibrary.Interfaces;

namespace UniLibrary.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService, ILogger<HomeController> logger)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBookDetailsAsync(filter: null, orderBy: null, a => a.Author!, c => c.Copies!);

            return View(books);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}