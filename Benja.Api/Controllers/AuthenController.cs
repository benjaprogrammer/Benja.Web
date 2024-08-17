﻿using Microsoft.AspNetCore.Mvc;
using Benja.Model;
using Benja.Repository;
using Benja.Service;
using Benja.Library;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Benja.Api.Controllers
{
    [ApiController]
    [Route("api/v1/authen")]
    public class AuthenController : BaseController
    {
        private readonly AuthenticationConfigurationModel _authenticationConfiguration;
        private readonly RefreshTokenRepo _refreshTokenRepo;
        public AuthenController(RefreshTokenRepo refreshTokenRepo, AuthenticationConfigurationModel authenticationConfigurationModel)
        {
            _refreshTokenRepo = refreshTokenRepo;
            _authenticationConfiguration = authenticationConfigurationModel;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserRepo userRepository = new UserRepo();

            UserModel userModel = new UserModel()
            {
                UserName = loginRequestModel.Username,
                Email = loginRequestModel.Email,
                FistName = "benja",
                LastName = "pattanasak",
                Password = "test",
                PasswordHash = new BcryptPasswordHasher().HashPassword("test")
            };
            userRepository.Create(userModel);

            userModel = userRepository.GetByUserName(loginRequestModel.Username);
            if (userModel == null)
            {
                return Unauthorized();
            };
            JwtService _jwtService = new JwtService(_authenticationConfiguration, _refreshTokenRepo);
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
            RefreshTokenModel refreshTokenModel = await _refreshTokenRepo.GetByToken(refreshRequestModel.RefreshToken);
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
        [Authorize]
        [HttpDelete("logout")]
        public IActionResult Logout()
        {
            string rawUserID = HttpContext.User.FindFirstValue("id");
            if (!Guid.TryParse(rawUserID, out Guid userID))
            {
                return Unauthorized();
            }
            _refreshTokenRepo.DeleteAll(userID);
            return NoContent();
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                IEnumerable<string> errorMessage = ModelState.Values.SelectMany(x => x.Errors.Select(y => y.ErrorMessage));
                return BadRequest(new ErrorResponseModel(errorMessage));
            }
            if (registerModel.Password != registerModel.ConfirmPassword)
            {
                return BadRequest(new ErrorResponseModel("Password does not match confirm password"));
            }
            UserRepo userRepo = new UserRepo();
            UserModel userModel = userRepo.GetByEmail(registerModel.Email);
            if (userModel != null)
            {
                return Conflict(new ErrorResponseModel("Email already exists"));
            }
            userModel = userRepo.GetByUserName(registerModel.UserName);
            if (userModel != null)
            {
                return Conflict(new ErrorResponseModel("Username already exists"));
            }

            userModel = new UserModel()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
                PasswordHash = new BcryptPasswordHasher().HashPassword(registerModel.Password)
            };
            userRepo.Create(userModel);
            return Ok();
        }
    }
}
