using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Benja.Model;
using Benja.Repository;
using Microsoft.IdentityModel.Tokens;
namespace Benja.Service
{
    public class JwtService
    {
        private readonly AuthenticationConfigurationModel _authenticationConfiguration;
        private readonly RefreshTokenRepo _refreshTokenRepo;
        public JwtService(AuthenticationConfigurationModel authenticationConfiguration,  RefreshTokenRepo refreshTokenRepo)
        {
            _authenticationConfiguration = authenticationConfiguration;
            _refreshTokenRepo = refreshTokenRepo;
        }

        public string GenerateToken(UserModel userModel)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Email,userModel.Email),
                new Claim(ClaimTypes.Name,userModel.UserName)
            };
            return GenerateTokenJwt(_authenticationConfiguration.AccessTokenSecret, _authenticationConfiguration.Issuer, _authenticationConfiguration.Audience, _authenticationConfiguration.AccessTokenExpirationMimutes, claims);
        }
        public string RefreshToken()
        {
            return GenerateTokenJwt(_authenticationConfiguration.RefreshTokenSecret, _authenticationConfiguration.Issuer, _authenticationConfiguration.Audience, _authenticationConfiguration.RefreshTokenExpirationMinutes);
        }
        public string GenerateTokenJwt(string secretKey, string issuer, string audience, double expirationMinutes, IEnumerable<Claim> claims = null)
        {
            SecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            JwtSecurityToken token = new JwtSecurityToken(
            issuer,
             audience,
                   claims,
            DateTime.UtcNow,
                   DateTime.UtcNow.AddMinutes(expirationMinutes),
                   credentials
                   );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public bool RefreshTokenValidate(string refreshToken)
        {
            TokenValidationParameters tokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationConfiguration.RefreshTokenSecret)),
                ValidIssuer = _authenticationConfiguration.Issuer,
                ValidAudience = _authenticationConfiguration.Audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                //ClockSkew = TimeSpan.Zero
            };
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            try
            {
                jwtSecurityTokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public AuthenticateUserModel Authenticate(UserModel userModel)
        {

            string accessToken = GenerateToken(userModel);
            string refreshToken = RefreshToken();
            RefreshTokenModel refreshTokenModel = new RefreshTokenModel()
            {
                Token = refreshToken,
                UserId = userModel.Id
            };
            _refreshTokenRepo.Create(refreshTokenModel);
            return new AuthenticateUserModel()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
