using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Web.Helper;
using Web.Models;

namespace Web.Controllers
{
    [Authorize(Roles = "SystemAdministrator,CompanyAdmin,Student")]
    public class HomeController : Web.Helper.AdminBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FileImport()
        {
            return View();
        }

        public ActionResult FileImportTemplate(string id)
        {
            var downloadName = string.Empty;
            byte[] bytes = null;
            switch (id)
            {
                case "S":
                    downloadName = "sample-student-data-import.xlsx";
                    bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/temp/STUDENTS_UPLOAD_TEMPLATE.xlsx"));
                    break;
                case "Q":
                    downloadName = "sample-question-data-import.xlsx";
                    bytes = System.IO.File.ReadAllBytes(Server.MapPath("~/temp/QUES_UPLOAD_TEMPLATE.xlsx"));
                    break;
                default:
                    break;
            }
            return File(bytes, "application/vnd-excel", downloadName);
        }

        [HttpPost]
        public ActionResult FileImport(VMUpload form)
        {
            if (ModelState.IsValid)
            {
                if (form != null && form.File != null && form.File.ContentLength > 0)
                {
                    var tempPath = string.Concat(HostingEnvironment.MapPath("~/temp/" + Guid.NewGuid().ToString()), Path.GetExtension(form.File.FileName)).ToLower();
                    form.File.SaveAs(tempPath);

                    var threadData = new Tuple<string, string, string>(tempPath, Company, LoggedUserID);
                    ThreadPool.QueueUserWorkItem((o) =>
                    {
                        var input = o as Tuple<string, string, string>;
                        if (input != null)
                        {
                            Web.Service.CommonService.Instance.ImportStudents(input.Item1, input.Item2, input.Item3);
                        }
                    }, threadData);
                }
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error500()
        {
            return View("500");
        }

        public void DownloadGridData(string gridData, DownloadFormat format, string fileName = null)
        {
            switch (format)
            {
                case DownloadFormat.XML:
                    Utility.ToXml(gridData, fileName);
                    break;
                case DownloadFormat.XLS:
                    Utility.ToExcel(gridData, fileName);
                    break;
                case DownloadFormat.CSV:
                    Utility.ToCsv(gridData, fileName);
                    break;
                default:
                    break;
            }
        }

        public enum DownloadFormat
        {
            XML = 0,
            XLS = 1,
            CSV = 2
        }

    }
}
