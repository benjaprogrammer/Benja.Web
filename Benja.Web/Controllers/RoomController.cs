using Benja.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class RoomController : BaseController
    {
        public RoomController(IHttpContextAccessor iHttpContextAccessor)
        {
            iHttpContextAccessor.HttpContext.Session.SetString("token", "test");
            Token = iHttpContextAccessor.HttpContext.Session.GetString("token");
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Test()
        {
            RoomListVM roomListVM = new RoomListVM();
            roomListVM.Token = Token;
            return View(roomListVM);
        }
    }
}
