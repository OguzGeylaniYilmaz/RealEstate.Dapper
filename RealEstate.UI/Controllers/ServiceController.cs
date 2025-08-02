using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
