using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/product")]
    public class ProductController : Controller
    {
        [HttpGet("getproduct")]
        public string GetProduct() {
            return "Success";
        }
    }
}
