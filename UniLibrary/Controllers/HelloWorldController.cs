using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UniLibrary.Models;

namespace UniLibrary.Controllers
{
    public class HelloWorldController : Controller
    {
        // localhost/HelloWorld/
        public IActionResult Index()
        {
            return View();
        }
        // localhost/HelloWorld/Welcome/3?name=Seanie
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}