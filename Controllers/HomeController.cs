using Microsoft.AspNetCore.Mvc;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models;
using System.Diagnostics;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Controllers
{
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
}
