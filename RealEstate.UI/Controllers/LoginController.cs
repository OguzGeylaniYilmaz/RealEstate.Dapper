using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using RealEstate.UI.Dtos.LoginDto;
using RealEstate.UI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateLoginDto createLogin)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(
                JsonSerializer.Serialize(createLogin),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://localhost:7047/api/Login", content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var jwtResponse = JsonSerializer.Deserialize<JwtResponseModel>(responseContent, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                });

                if (jwtResponse != null)
                {
                    JwtSecurityTokenHandler jwtSecurityToken = new();
                    var token = jwtSecurityToken.ReadJwtToken(jwtResponse.Token);
                    var claims = token.Claims.ToList();

                    if (jwtResponse.Token != null && claims.Count > 0)
                    {
                        claims.Add(new Claim("realstatetoken", jwtResponse.Token));
                        var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
                        var athenticationProperties = new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = jwtResponse.Expiration.ToUniversalTime()
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), athenticationProperties);
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
        }

    }
}
