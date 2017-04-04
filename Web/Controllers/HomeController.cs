using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helper;

namespace Web.Controllers
{
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

        [AllowAnonymous]
        public ActionResult Error500()
        {
            return View("500");
        }

        public void DownloadGridData(String gridData, DownloadFormat format)
        {
            switch (format)
            {
                case DownloadFormat.XML:
                    Utility.ToXml(gridData);
                    break;
                case DownloadFormat.XLS:
                    Utility.ToExcel(gridData);
                    break;
                case DownloadFormat.CSV:
                    Utility.ToCsv(gridData);
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
