using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniLibrary.Models;
using System.Text.Encodings.Web;

namespace UniLibrary.Controllers
{
    public class HelloWorldController : Controller
    {
        // localhost/HelloWorld/
        public string Index()
        {
            return "This is my default action...";
        }
        // localhost/HelloWorld/Welcome/3?name=Seanie
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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
