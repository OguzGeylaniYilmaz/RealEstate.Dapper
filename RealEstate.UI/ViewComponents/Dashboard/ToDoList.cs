using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.ToDoDtos;

namespace RealEstate.UI.ViewComponents.Dashboard
{
    public class ToDoList : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ToDoList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/ToDos");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var todos = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
                return View(todos);
            }
            return View();
        }

    }
}
