using Benja.Model;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class AuthenController : BaseController
    {
        public AuthenController()
        {
           
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
    }
}
