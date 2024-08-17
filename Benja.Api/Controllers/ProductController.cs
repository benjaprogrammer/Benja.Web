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
        public JsonResult GetListByName([FromBody] DtParameters dtParameters)
        {
            var searchBy = dtParameters.search?.Value;

            var orderCriteria = "given_name";
            var orderAscendingDirection = true;

            if (dtParameters.order != null)
            {
                orderCriteria = dtParameters.columns[dtParameters.order[0].Column].Data;
                if (orderCriteria == "0")
                {
                    orderCriteria = "given_name";
                }
                orderAscendingDirection = dtParameters.order[0].Dir.ToString().ToLower() == "asc";
            }
            SiteRepo siteRepo = new SiteRepo();
            IEnumerable<SiteModel> listSiteModel = siteRepo.GetAll();
            var result = listSite.AsQueryable();

            if (!string.IsNullOrEmpty(searchBy))
            {
                result = result.Where(r => (r..ToLower() != null && r.Document_No.ToLower().Contains(searchBy.ToLower())));

            }
            result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

            var filteredResultsCount = result.Count();
            var totalResultsCount = listBlackList.Count();

            return Json(new DtResult<BlackListModel>
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
