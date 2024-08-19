using Benja.Library;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Api.Controllers
{
    public class BaseController : Controller
    {
        public SqlServer _sqlServer;
    }
}
