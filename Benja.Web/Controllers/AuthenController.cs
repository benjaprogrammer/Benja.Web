using Benja.Model;
using Microsoft.AspNetCore.Mvc;
using Benja.Service;
using Benja.Library;
using System.ComponentModel.DataAnnotations;
namespace Benja.Web.Controllers
{
    public class AuthenController : BaseController
    {
        public AuthenController(IHttpClientFactory iHttpClientFactory, HTTP http)
        {
            _iHttpClientFactory = iHttpClientFactory;
            _http = http;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            HttpContext.Session.SetString("token", "test");
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> Register([FromBody] RegisterModel registerModel)
        {
            registerModel.id = 1;
            registerModel.createBy = string.Empty;
            registerModel.createDate = DateTime.Now;
            registerModel.updateDate = DateTime.Now;
            registerModel.updateBy = string.Empty;
            registerModel.migrationGuID = Guid.NewGuid();
            registerModel.passwordHash = string.Empty;
            AuthenService authenService = new AuthenService(_iHttpClientFactory, _http);
            return Json(await authenService.Register(registerModel));
        }
        [HttpPost]
        public async Task<JsonResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            AuthenService authenService = new AuthenService(_iHttpClientFactory, _http);
            ApiResponse<AuthenticateUserModel> authenticateUserModel = authenService.Login(loginRequestModel).Result;
            HttpContext.Session.SetString("AccessToken", authenticateUserModel.Data.AccessToken);
            return Json(authenticateUserModel);
        }
    }
}

