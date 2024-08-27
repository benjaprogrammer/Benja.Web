using Benja.Model;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class BaseController : Controller
    {
        public IWebHostEnvironment _iWebHostEnvironment;
        public IHttpContextAccessor _iHttpContextAccessor;
        public string Token;
        public BaseController()
        {
         
        }
    }
}
