using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class OurServices : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
