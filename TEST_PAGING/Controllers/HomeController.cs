using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TEST_PAGING.Models;
using TEST_PAGING.VDCBackOfficeService;

namespace TEST_PAGING.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public JsonResult dataTable(String ConsularMappingId)
        {
            string json = string.Empty;
            VDC_ATV_MST_CONSULAR serv = new VDC_ATV_MST_CONSULAR();
            var result = serv.GetAllDATA(ConsularMappingId);
      
            int tempCount = result.Count();
            var aa = new {
                recordsFiltered = tempCount,
                recordsTotal = tempCount,
                data = result
            };
            var jsonResult = Json(aa, JsonRequestBehavior.AllowGet);
            //  jsonResult.MaxJsonLength = int.MaxValue;
            jsonResult.ContentType = "application/json";
            jsonResult.ContentEncoding = Encoding.GetEncoding("UTF-8");
            return jsonResult;

        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}