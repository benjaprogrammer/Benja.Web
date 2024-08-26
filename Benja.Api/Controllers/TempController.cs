using Benja.Library;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Benja.Api.Controllers
{
    public class TempController : BaseController
    {
        public TempController(IWebHostEnvironment iWebHostEnvironment)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        [HttpPost]
        public JsonResult SaveImage()
        {
            try
            {
                var postFile = Request.Form.Files[0];
                string fileName = postFile.FileName;
                string physicalpath = _iWebHostEnvironment.ContentRootPath + "/image/" + fileName;
                Images img = new Images();
                img.SaveImage(physicalpath, postFile); 
                return new JsonResult(fileName);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        //[HttpPost("getlist")]
        //public JsonResult GetList([FromBody] DtParameters dtParameters)
        //{
        //    var searchBy = dtParameters.search?.Value;

        //    var orderCriteria = "";
        //    var orderAscendingDirection = true;

        //    if (dtParameters.order != null)
        //    {
        //        orderCriteria = dtParameters.columns[dtParameters.order[0].Column].Data;
        //        if (orderCriteria == "0")
        //        {
        //            orderCriteria = "";
        //        }
        //        orderAscendingDirection = dtParameters.order[0].Dir.ToString().ToLower() == "asc";
        //    }
        //    SiteRepo siteRepo = new SiteRepo();
        //    IEnumerable<SiteModel> listSiteModel = siteRepo.GetAll();
        //    var result = listSiteModel.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchBy))
        //    {
        //        result = result.Where(r => (r.f_site_name.ToLower() != null && r.f_site_name.ToLower().Contains(searchBy.ToLower())));

        //    }
        //    result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

        //    var filteredResultsCount = result.Count();
        //    var totalResultsCount = listSiteModel.Count();

        //    return Json(new DtResult<SiteModel>
        //    {
        //        Draw = dtParameters.draw,
        //        RecordsTotal = totalResultsCount,
        //        RecordsFiltered = filteredResultsCount,
        //        Data = result
        //            .Skip(dtParameters.start)
        //            .Take(dtParameters.length)
        //            .ToList()
        //    });
        //}
    }
}
