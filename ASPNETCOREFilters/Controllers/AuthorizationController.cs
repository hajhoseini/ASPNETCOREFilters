using ASPNETCOREFilters.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREFilters.Controllers
{
    public class AuthorizationController : Controller
    {
        [CustomAuthorizationFilter("admin")]
        public IActionResult Index()
        {
            return View();
        }

        [CustomAuthorizationFilter("customer")]
        public IActionResult Index2()
        {
            return View();
        }
    }
}
