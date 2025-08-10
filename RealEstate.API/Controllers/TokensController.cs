using Microsoft.AspNetCore.Mvc;
using RealEstate.API.Tools;

namespace RealEstate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        [HttpGet]
        public IActionResult CreateToken(GetCheckAppUserViewModel appUserViewModel)
        {

            var values = JwtTokenGenerator.GenerateToken(appUserViewModel);
            return Ok(values);
        }
    }
}