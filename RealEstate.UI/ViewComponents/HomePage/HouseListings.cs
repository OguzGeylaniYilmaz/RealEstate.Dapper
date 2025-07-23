using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class HouseListings : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
