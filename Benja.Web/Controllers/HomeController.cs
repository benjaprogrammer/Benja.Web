using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Benja.Repository;
using Benja.Model;
using Benja.ViewModel;
namespace Benja.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SiteVM siteVM = new SiteVM();
            siteVM.listSiteModel = new SiteRepo().GetAll().ToList();
            return View(siteVM);
        }
    }
}
