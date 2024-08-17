using Benja.Library;
using Benja.Model;
using Benja.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Benja.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/product")]
    public class ProductController : BaseController
    {
        [HttpGet("getproduct")]
        public string GetProduct() {
            return "Success";
        }
        [HttpPost]
        public JsonResult GetList([FromBody] DtParameters dtParameters)
        {
            var searchBy = dtParameters.search?.Value;

            var orderCriteria = "";
            var orderAscendingDirection = true;

            if (dtParameters.order != null)
            {
                orderCriteria = dtParameters.columns[dtParameters.order[0].Column].Data;
                if (orderCriteria == "0")
                {
                    orderCriteria = "";
                }
                orderAscendingDirection = dtParameters.order[0].Dir.ToString().ToLower() == "asc";
            }
            SiteRepo siteRepo = new SiteRepo();
            IEnumerable<SiteModel> listSiteModel = siteRepo.GetAll();
            var result = listSiteModel.AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => (r.f_site_name.ToLower() != null && r.f_site_name.ToLower().Contains(searchBy.ToLower())));

            }
            result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

            var filteredResultsCount = result.Count();
            var totalResultsCount = listSiteModel.Count();

            return Json(new DtResult<SiteModel>
            {
                Draw = dtParameters.draw,
                RecordsTotal = totalResultsCount,
                RecordsFiltered = filteredResultsCount,
                Data = result
                    .Skip(dtParameters.start)
                    .Take(dtParameters.length)
                    .ToList()
            });
        }
    }
}
