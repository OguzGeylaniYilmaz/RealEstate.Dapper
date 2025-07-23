using Microsoft.AspNetCore.Mvc;

namespace RealEstate.UI.ViewComponents.HomePage
{
    public class PopularLocations : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // Here you would typically fetch data from a service or database
            // For demonstration purposes, we will return a simple view
            return View();
        }
    }
}
