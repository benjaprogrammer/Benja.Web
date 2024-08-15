using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Benja.Model;
using Microsoft.IdentityModel.Tokens;
namespace Benja.Service
{
    public class TokenService
    {
        private readonly AuthenticationConfiguration _authenticationConfiguration;

        public TokenService(AuthenticationConfiguration authenticationConfiguration)
        {
            _authenticationConfiguration = authenticationConfiguration;
        }
        public string GenerateToken(UserModel userModel)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.AccessTokenSecret));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email,userModel.Email),
                new Claim(ClaimTypes.Name,userModel.UserName)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                _authenticationConfiguration.Issuer,
               _authenticationConfiguration.Audience,
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(_authenticationConfiguration.AccessTokenExpirationMimutes),
                credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
