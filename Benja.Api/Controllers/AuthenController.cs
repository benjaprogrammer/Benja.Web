using Microsoft.AspNetCore.Mvc;
using Benja.Model;
using Benja.Repository;
using Benja.Service;
namespace Benja.Api.Controllers
{
    [ApiController]
    [Route("api/v1/authen")]
    public class AuthenController : Controller
    {
        private readonly TokenService _tokenService;
        public AuthenController(TokenService tokenService) {
            _tokenService= tokenService;    
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserRepository userRepository = new UserRepository();
            UserModel userModel =  userRepository.GetByUserName(loginRequestModel.Username);
            if (userModel == null)
            {
                return Unauthorized();
            }
            string accessToken = _tokenService.GenerateToken(userModel);
            return Ok(new AuthenticateUserResponse() { 
                AccessToken= accessToken
            });
        }
    }
}
