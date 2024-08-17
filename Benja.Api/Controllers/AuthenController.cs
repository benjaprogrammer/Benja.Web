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
        private readonly AuthenticationConfigurationModel _authenticationConfiguration;

        //private readonly JwtService _jwtService;
        private readonly RefreshTokenRepo _refreshTokenRepo;
        public AuthenController( RefreshTokenRepo refreshTokenRepo, AuthenticationConfigurationModel authenticationConfigurationModel)
        {
            //_jwtService = jwtService;
            _refreshTokenRepo = refreshTokenRepo;
            _authenticationConfiguration= authenticationConfigurationModel;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserRepo userRepository = new UserRepo();
            UserModel userModel = userRepository.GetByUserName(loginRequestModel.Username);
            if (userModel == null)
            {
                return Unauthorized();
            };
            JwtService _jwtService = new JwtService(_authenticationConfiguration,_refreshTokenRepo);
            AuthenticateUserModel authenticateUserModel = _jwtService.Authenticate(userModel);
            return Ok(authenticateUserModel);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestModel refreshRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            JwtService _jwtService = new JwtService(_authenticationConfiguration, _refreshTokenRepo);
            bool isValidRefreshToken = _jwtService.RefreshTokenValidate(refreshRequestModel.RefreshToken);
            if (!isValidRefreshToken)
            {
                return BadRequest(new ErrorResponseModel("Invalid refresh token"));
            }
            RefreshTokenModel refreshTokenModel =await _refreshTokenRepo.GetByToken(refreshRequestModel.RefreshToken);
            if (refreshTokenModel == null)
            {
                return NotFound(new ErrorResponseModel("Invalid refresh token"));
            }
            await _refreshTokenRepo.Delete(refreshTokenModel.Id);
            UserModel userModel = new UserRepo().GetById(refreshTokenModel.UserId);
            if (userModel == null)
            {
                return NotFound(new ErrorResponseModel("User not found"));
            }
            AuthenticateUserModel authenticateUserModel = _jwtService.Authenticate(userModel);
            return Ok(authenticateUserModel);
        }
    }
}
