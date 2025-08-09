using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RealEstate.API.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrEmpty(model.Role))
                claims.Add(new Claim(ClaimTypes.Role, model.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()));

            if (!string.IsNullOrEmpty(model.Username))
                claims.Add(new Claim(ClaimTypes.Name, model.Username));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.SecretKey)); // Replace with your actual secret key
            var signInCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddMinutes(JwtTokenDefaults.ExpirationMinutes);

            JwtSecurityToken token = new(
                issuer: JwtTokenDefaults.ValidIssuer,
                audience: JwtTokenDefaults.ValidAudience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expiration,
                signingCredentials: signInCredentials
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new();
            return new TokenResponseViewModel(
                token: jwtSecurityTokenHandler.WriteToken(token),
                expireDate: expiration
            );

        }
    }
}
