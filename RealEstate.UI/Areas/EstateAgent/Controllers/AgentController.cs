using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class AgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
