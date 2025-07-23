using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // You can pass any model or data to the view if needed
            return View();
        }
    }
}
