using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class BaseController : Controller
    {
        public IWebHostEnvironment _iWebHostEnvironment;
        public BaseController()
        {
        }
    }
}
