using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class MyAdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
