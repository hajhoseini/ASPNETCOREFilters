using ASPNETCOREFilters.Models.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCOREFilters.Controllers
{
    public class ResourceController : Controller
    {
        //[CustomResourceFilter]
        [TypeFilter(typeof(CustomResourceFilter))]
        public IActionResult Index()
        {
            string value = $"time is {DateTime.Now.TimeOfDay}";
            return View("Index", value);
        }
    }
}
