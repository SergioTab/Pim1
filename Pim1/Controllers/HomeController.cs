using Microsoft.AspNetCore.Mvc;
using Pim1.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Pim1.Controllers
{
    public class HomeController : Controller
    {
       
        public IActionResult Index()
        {
            HomeModel home = new HomeModel();

            home.Nome = "Usuario";
            home.Email = "Usuario@gmail.com";

            return View(home);
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
