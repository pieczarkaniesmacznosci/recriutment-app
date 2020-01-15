using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RecApp.Models;
using RecApp.Models.ViewModels;

namespace RecApp.Controllers
{
    public class HomeController : Controller
    {
        private HomeViewModel homeViewModel;

        public HomeController()
        {
            this.homeViewModel = new HomeViewModel();
        }
        public IActionResult Index()
        {
            var candidatesList = this.homeViewModel;
            return View(candidatesList);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
