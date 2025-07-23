using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
