using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WebForms;
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
        public JsonResult dataTable(Datatable model)
        {
            string json = string.Empty;
            VDC_ATV_MST_CONSULAR serv = new VDC_ATV_MST_CONSULAR();
            // action inside a standard controller
            int filteredResultsCount;
            int totalResultsCount;
            var res = serv.YourCustomSearchFunc(model, out filteredResultsCount, out totalResultsCount);
            
      
 
            var aa = new {
                recordsFiltered = filteredResultsCount,
                recordsTotal = totalResultsCount,
                data = res
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

        public FileResult Print()
        {
            
           // var result = watchList.GetApplicantPrint(target);
            ReportViewer ReportViewer1 = new ReportViewer();
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Example.rdlc");
     

           // ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
           // ReportViewer1.LocalReport.DataSources.Add(datasource);
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;


            byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            //var res = new PrintApplication();



            //res.pdf = Convert.ToBase64String(bytes, 0, bytes.Length);
            string ReportName = "Example.pdf";

            




            return File(bytes, System.Net.Mime.MediaTypeNames.Application.Octet, ReportName);
        }
    }
}