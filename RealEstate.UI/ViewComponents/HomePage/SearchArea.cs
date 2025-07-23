using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class SearchArea : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
