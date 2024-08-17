using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Benja.Repository;
using Benja.Model;
using Benja.ViewModel;
using Benja.Library;
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
            return View();
        }
       
    }
}
