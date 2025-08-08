using Microsoft.AspNetCore.SignalR;

namespace RealEstate.API.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SignalRHub(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

        public async Task SendActiveCategoryCount()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7047/api/Statistic/active-category-count");
            var jsonData = await response.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", jsonData);
        }
    }
}
