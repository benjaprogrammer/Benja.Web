using Benja.Library;
using Benja.Model;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class BaseController : Controller
    {
        public IWebHostEnvironment _iWebHostEnvironment;
        public IHttpContextAccessor _iHttpContextAccessor;
        public IHttpClientFactory _iHttpClientFactory;
        public string Token;
        public HTTP _http;
        public BaseController()
        {
         
        }
    }
}
