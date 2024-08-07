using ASPNETCOREFilters.Models;
using ASPNETCOREFilters.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREFilters.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [CustomActionFilter]
        [HttpPost]
        public IActionResult Create([FromForm] ProductViewModel product) 
        {
            return View();
        }
    }
}
