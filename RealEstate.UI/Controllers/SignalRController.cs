using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Controllers
{
    public class SignalRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
