using Benja.Service;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Web.Controllers
{
    public class TempController : BaseController
    {
        public TempController(IHttpClientFactory iHttpClientFactory)
        {
            _iHttpClientFactory = iHttpClientFactory;
        }
        public IActionResult Index()
        {
            MenuService menuService = new MenuService(_iHttpClientFactory);
            menuService.GetItem();
            return View();
        }
     
    }
}
