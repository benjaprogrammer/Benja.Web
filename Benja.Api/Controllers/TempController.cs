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
    }
}
