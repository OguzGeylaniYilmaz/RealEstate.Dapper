using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
