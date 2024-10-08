using ASPNETCOREFilters.Models;
using ASPNETCOREFilters.Models.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPNETCOREFilters.Controllers
{
    [ShowMessageFilter("Contoller")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [ShowMessageFilter("Action")]
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

        [TypeFilter(typeof(CustomExceptionFilter))]
        public IActionResult Error2()
        {
            throw new NotImplementedException();
        }

        //[CustomResultFilter]
        [ServiceFilter(typeof(CustomExceptionFilter))]
        public IActionResult ResultTest()
        {
            return View();
        }
    }
}