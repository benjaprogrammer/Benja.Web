using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
