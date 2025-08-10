using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.EstateAgent
{
    public class AgentSidebar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // You can pass any model or data to the view if needed
            return View();
        }
    }
}
