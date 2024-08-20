using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class RoomController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
