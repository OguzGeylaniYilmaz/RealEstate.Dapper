namespace RealEstate.API.Tools
{
    public class JwtTokenDefault
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string SecretKey = "RealEstate..12345678";
        public const int ExpirationMinutes = 10; // Token expiration time in minutes
    }
}
