using Benja.Library;
using Benja.Model;
using Benja.Service;
using Benja.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Benja.Web.Controllers
{
    public class TempController : BaseController
    {
        public TempController(IHttpClientFactory iHttpClientFactory, HTTP http)
        {
            _iHttpClientFactory = iHttpClientFactory;
            _http = http;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetItem()
        {
            MenuService menuService = new MenuService(_iHttpClientFactory, _http);
            return Json(await menuService.GetItem());
        }
        [HttpPost]
        public async Task<JsonResult> Add([FromBody] MenuVm menuVm)
        {
            string test=JsonConvert.SerializeObject(menuVm);
            MenuService menuService = new MenuService(_iHttpClientFactory, _http);
            return Json(await menuService.Add(menuVm.menuModel));
        }
    }
}
