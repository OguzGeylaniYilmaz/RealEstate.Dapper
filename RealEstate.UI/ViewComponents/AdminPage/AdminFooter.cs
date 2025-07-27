using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.AdminPage
{
    public class AdminFooter : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
