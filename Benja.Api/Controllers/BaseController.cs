using Microsoft.AspNetCore.Mvc;

namespace Benja.Api.Controllers
{
    public class BaseController : Controller
    {
        public string status = @"{{""status"":""{0}"",""data"":""{1}""}}";
        public string statusError = @"{{""status"":""{0}"",""error"":""{1}""}}";
        public enum Status
        {
            success,
            fail
        }
    }
}
