using System.Diagnostics;
using Glass.Htmx.Demo.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using Glass.Htmx;

namespace Glass.Htmx.Demo.Mvc.Controllers
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

        [Route("/page/{page}")]
        public IActionResult Page(string page)
        {
            return View(page);
        }
        [Route("/page/slow/{page}")]
        public async Task<IActionResult> PageSlow(string page)
        {
            await Task.Delay(1000);
            return View(page);
        }
    }
}
