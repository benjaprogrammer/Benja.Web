using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Benja.Repository;
using Benja.Model;

using Benja.Library;
using Newtonsoft.Json;
using Benja.Service;
namespace Benja.Web.Controllers
{
    public class HomeController : BaseController
    {
        //private readonly IExportService<SiteModel> _exportService;

        //public HomeController(IExportService<SiteModel> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpPost]
        //public async Task<IActionResult> ExportTable([FromQuery] string format, [FromForm] string dtParametersJson)
        //{
        //    var dtParameters = new DtParameters();
        //    if (!string.IsNullOrEmpty(dtParametersJson))
        //    {
        //        dtParameters = JsonConvert.DeserializeObject<DtParameters>(dtParametersJson);
        //    }

        //    if (dtParameters != default)
        //    {
        //        var searchBy = dtParameters.search?.Value;

        //        var orderCriteria = "Id";
        //        var orderAscendingDirection = true;

        //        if (dtParameters.order != null)
        //        {
        //            orderCriteria = dtParameters.columns[dtParameters.order[0].Column].Data;
        //            orderAscendingDirection = dtParameters.order[0].Dir.ToString().ToLower() == "asc";
        //        }

        //        var result = new SiteRepo().GetAll().AsQueryable();

        //        if (!string.IsNullOrEmpty(searchBy))
        //        {
        //            result = result.Where(r => r.f_site_name != null && r.f_site_name.ToUpper().Contains(searchBy.ToUpper()));
        //        }

        //        result = orderAscendingDirection ? result.OrderByDynamic(orderCriteria, DtOrderDir.Asc) : result.OrderByDynamic(orderCriteria, DtOrderDir.Desc);

        //        var resultList =  result.ToList();

        //        switch (format)
        //        {
        //            case ExportFormatModel.Excel:
        //                return File(
        //                    await _exportService.ExportToExcel(resultList),
        //                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
        //                    "data.xlsx");

        //            case ExportFormatModel.Csv:
        //                return File(_exportService.ExportToCsv(resultList),
        //                    "application/csv",
        //                    "data.csv");

        //            case ExportFormatModel.Html:
        //                return File(_exportService.ExportToHtml(resultList),
        //                    "application/csv",
        //                    "data.html");

        //            case ExportFormatModel.Json:
        //                return File(_exportService.ExportToJson(resultList),
        //                    "application/json",
        //                    "data.json");

        //            case ExportFormatModel.Xml:
        //                return File(_exportService.ExportToXml(resultList),
        //                    "application/xml",
        //                    "data.xml");

        //            case ExportFormatModel.Yaml:
        //                return File(_exportService.ExportToYaml(resultList),
        //                    "application/yaml",
        //                    "data.yaml");
        //        }
        //    }
        //    return null;
        //}

    }
}
