using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.AdminPage
{
    public class AdminSpinner : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
