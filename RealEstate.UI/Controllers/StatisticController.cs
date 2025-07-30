using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
