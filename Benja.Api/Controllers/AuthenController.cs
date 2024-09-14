using Microsoft.AspNetCore.Mvc;
using Benja.Model;
using Benja.Repository;
using Benja.Service;
using Benja.Library;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using static QRCoder.PayloadGenerator;
using System.Data.SqlClient;
namespace Benja.Api.Controllers
{
    [ApiController]
    [Route("api/v1/authen")]
    public class AuthenController : BaseController
    {
        private readonly AuthenticationConfigurationModel _authenticationConfiguration;
        private readonly RefreshTokenRepo _refreshTokenRepo;
        public AuthenController(RefreshTokenRepo refreshTokenRepo, AuthenticationConfigurationModel authenticationConfigurationModel, SqlServer sqlServer)
        {
            _sqlServer = sqlServer;
            _refreshTokenRepo = refreshTokenRepo;
            _authenticationConfiguration = authenticationConfigurationModel;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            ApiResponse<AuthenticateUserModel> response = new ApiResponse<AuthenticateUserModel>();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Success = false;
                    response.ErrorMessage = "BadRequest";
                    return BadRequest(ModelState);
                }
                UserRepo userRepo = new UserRepo(_sqlServer);
                List<UserModel> listUserModel = userRepo.GetByEmail<UserModel>(loginRequestModel.email).Result.ToList();
                if (listUserModel.Count == 0)
                {
                    response.Success = false;
                    response.ErrorMessage = "Unauthorized";
                    return Unauthorized();
                };
                JwtService _jwtService = new JwtService(_authenticationConfiguration, _refreshTokenRepo);
                response.Data = _jwtService.Authenticate(listUserModel[0]);
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return Ok(response);
        }
        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestModel refreshRequestModel)
        {
            ApiResponse<AuthenticateUserModel> response = new ApiResponse<AuthenticateUserModel>();
            try
            {
                if (!ModelState.IsValid)
                {
                    response.Success = false;
                    response.ErrorMessage = "BadRequest";
                    return BadRequest(ModelState);
                }
                JwtService _jwtService = new JwtService(_authenticationConfiguration, _refreshTokenRepo);
                bool isValidRefreshToken = _jwtService.RefreshTokenValidate(refreshRequestModel.RefreshToken);
                if (!isValidRefreshToken)
                {
                    response.Success = false;
                    response.ErrorMessage = "Invalid refresh token";
                    return BadRequest(new ErrorResponseModel("Invalid refresh token"));
                }
                RefreshTokenModel refreshTokenModel = await _refreshTokenRepo.GetByToken(refreshRequestModel.RefreshToken);
                if (refreshTokenModel == null)
                {
                    response.Success = false;
                    response.ErrorMessage = "Invalid refresh token";
                    return NotFound(new ErrorResponseModel("Invalid refresh token"));
                }
                await _refreshTokenRepo.Delete(refreshTokenModel.Id);
                //UserModel userModel = new UserRepo(_sqlServer).GetById(refreshTokenModel.UserId);
                //if (userModel == null)
                //{
                //    response.Success = false;
                //    response.ErrorMessage = "User not found";
                //    return NotFound(new ErrorResponseModel("User not found"));
                //}
                //response.Data = _jwtService.Authenticate(userModel);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return Ok(response);
        }
        [Authorize]
        [HttpDelete("logout")]
        public IActionResult Logout()
        {
            ApiResponse<string> response = new ApiResponse<string>();
            try
            {
                string rawUserID = HttpContext.User.FindFirstValue("id");
                if (!int.TryParse(rawUserID, out int userID))
                {
                    response.Success = false;
                    response.ErrorMessage = "Unauthorized";
                    return Unauthorized();
                }
                _refreshTokenRepo.DeleteAll(userID);
                response.Data = "Logout Success";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }
            return Ok(response);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel registerModel)
        {
            ApiResponse<int> response = new ApiResponse<int>();
            try
            {
                if (!ModelState.IsValid)
                {
                    IEnumerable<string> errorMessage = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
                    return BadRequest(new ErrorResponseModel(errorMessage));
                }
                if (registerModel.password != registerModel.confirmPassword)
                {
                    return BadRequest(new ErrorResponseModel("Password does not match confirm password"));
                }
                UserRepo userRepo = new UserRepo(_sqlServer);
                List<UserModel> listUserModel = userRepo.GetByEmail<UserModel>(registerModel.email).Result.ToList();
                if (listUserModel.Count == 1)
                {
                    response.ErrorMessage = "Email already exists";
                }
                else
                {
                    response.Data = await userRepo.Add(registerModel);
                }
            }
            catch (SqlException ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;
            }
            return Ok(response);
        }
    }
}
