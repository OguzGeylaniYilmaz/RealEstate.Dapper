using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class DealOfTheDay : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
