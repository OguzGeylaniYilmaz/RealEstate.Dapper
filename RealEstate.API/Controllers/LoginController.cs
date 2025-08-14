using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Dtos.CreateLoginDtos;
using RealEstate.API.Models.DapperContext;
using RealEstate.API.Tools;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto createLogin)
        {
            string query = "SELECT * FROM AppUser WHERE Username = @Username AND Password = @Password";
            var parameters = new DynamicParameters();
            parameters.Add("@Username", createLogin.Username);
            parameters.Add("@Password", createLogin.Password);

            using var connection = _context.CreateConnection();
            var user = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
            if (user != null)
            {
                GetCheckAppUserViewModel userViewModel = new();
                userViewModel.Username = user.Username;
                userViewModel.Id = user.UserID;
                var token = JwtTokenGenerator.GenerateToken(userViewModel);
                return Ok(token);
            }
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    }
}
