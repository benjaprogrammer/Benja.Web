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
        [HttpPost]
        public JsonResult Login([FromBody] LoginRequestModel loginRequestModel)
        {
            AuthenService authenService =new AuthenService(_iHttpClientFactory,_http);
            return Json("");//authenService.SignIn()
        }
		public IActionResult Register()
		{
			return View();
		}
        [HttpPost]
		public async Task<JsonResult> Register([FromBody] RegisterModel registerModel)
		{
            //"email": null,
            //    "userName": null,
            //    "password": null,
            //    "confirmPassword": null,
            //    "id": 0,
            //    "createDate": "0001-01-01T00:00:00",
            //    "createBy": null,
            //    "updateDate": "0001-01-01T00:00:00",
            //    "updateBy": null,
            //    "migrationGuID": "00000000-0000-0000-0000-000000000000"
            registerModel.userName = string.Empty;
            registerModel.id = 1;
            registerModel.createBy = string.Empty;
            registerModel.createDate = DateTime.Now;
            registerModel.updateDate = DateTime.Now;
            registerModel.updateBy = string.Empty;
            registerModel.migrationGuID = Guid.NewGuid();
            AuthenService authenService = new AuthenService(_iHttpClientFactory, _http);
            return Json(await authenService.Register(registerModel));
        }
	}
}

