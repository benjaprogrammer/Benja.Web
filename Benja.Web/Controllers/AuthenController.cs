using Benja.Model;
using Microsoft.AspNetCore.Mvc;
using Benja.Service;
using Benja.Library;
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
            registerModel.id = 0;
            registerModel.createBy = "";
            registerModel.createDate = DateTime.Now;
            registerModel.updateDate = DateTime.Now;
            registerModel.updateBy = "";
            AuthenService authenService = new AuthenService(_iHttpClientFactory, _http);
            return Json(await authenService.Register(registerModel));
        }
	}
}

