using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.AdminPage
{
    public class AdminScripts : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
