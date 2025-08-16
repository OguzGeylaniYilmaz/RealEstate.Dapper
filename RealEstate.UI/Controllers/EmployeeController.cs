using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate.UI.Dtos.EmployeeDtos;

namespace RealEstate.UI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> Index()
        {
            var token = User.Claims.FirstOrDefault(c => c.Type == "realstatetoken")?.Value;

            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://localhost:7047/api/Employees");

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                    return View(employees);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            if (!ModelState.IsValid)
            {
                return View(createEmployeeDto);
            }
            var client = _httpClientFactory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(createEmployeeDto);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7047/api/Employees", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to create employee.");
            return View(createEmployeeDto);

        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7047/api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7047/api/Employees/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var employee = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(employee);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployee)
        {
            if (!ModelState.IsValid)
            {
                return View(updateEmployee);
            }
            var client = _httpClientFactory.CreateClient();
            var jsonContent = JsonConvert.SerializeObject(updateEmployee);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7047/api/Employees/", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Failed to update employee.");
            return View();
        }

    }
}