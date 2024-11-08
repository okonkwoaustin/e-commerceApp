using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_commerceApp.Application.Services.Implementation
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<TokenService> _logger;

        public TokenService(IConfiguration configuration, ILogger<TokenService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        
        public string GenerateToken(User user, List<string> roles)
        {
            try
            {
                TimeSpan? expiration = null;
                var claims = CreateClaims(user, roles);
                var options = GetOptions();
                var now = DateTime.UtcNow;

                var jwtSecurityToken = new JwtSecurityToken(
                    issuer: options.Issuer,
                    audience: options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(expiration ?? options.Expiration),
                    signingCredentials: options.SigningCredentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error authenticating user: {ex.Message} {ex.StackTrace} ");
                throw;
            }
        }

        private List<Claim> CreateClaims(User user, List<string> roles)
        {
            var claims = new List<Claim>();
            claims.AddRange(new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim("phoneNumber", user.PhoneNumber),
                new Claim("UserId", user.Id.ToString())
            });
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }


        public TokenProviderOptions GetOptions()
        {
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Authentication:JwtBearer:SecretKey").Value));

            return new TokenProviderOptions
            {
                Audience = _configuration.GetSection("Authentication:JwtBearer:Audience").Value,
                Issuer = _configuration.GetSection("Authentication:JwtBearer:Issuer").Value,
                Expiration = TimeSpan.FromMinutes(Convert.ToInt32(_configuration.GetSection("Authentication:JwtBearer:AccessExpiration").Value)),
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            };
        }


        public class TokenProviderOptions
        {
            public SymmetricSecurityKey SecurityKey { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public SigningCredentials SigningCredentials { get; set; }
            public TimeSpan Expiration { get; set; }
        }


        //public string GenerateToken(User user, List<string> roles)
        //{
        //    try
        //    {
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("Authentication:JwtBearer:SecretKey").Value);
        //        var minutes = Convert.ToDouble(_configuration.GetSection("Authentication:JwtBearer:AccessExpiration").Value);
        //        var claims = new List<Claim>
        //    {
        //        new Claim(ClaimTypes.Email, user.Email),
        //        new Claim("firstName", user.FirstName),
        //        new Claim("lastName", user.LastName),
        //        new Claim("userId", user.Id.ToString())

        //    };

        //        foreach (var role in roles)
        //        {
        //            claims.Add(new Claim(ClaimTypes.Role, role));
        //        }

        //        var tokenDesctiptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(claims),
        //            Expires = DateTime.UtcNow.AddHours(minutes),
        //            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
        //            SecurityAlgorithms.HmacSha256Signature),
        //            Audience = _configuration.GetSection("Authentication:JwtBearer:Audience").Value,
        //            Issuer = _configuration.GetSection("Authentication:JwtBearer:Issuer").Value
        //        };
        //        var token = tokenHandler.CreateToken(tokenDesctiptor);
        //        return tokenHandler.WriteToken(token);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Error authenticating user: {ex.Message} {ex.StackTrace}");
        //        throw;
        //    }
        //}
    }
}
