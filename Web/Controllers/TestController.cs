using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    [Authorize(Roles = "SystemAdministrator,CompanyAdmin")]
    public class TestController : Web.Helper.AdminBaseController
    {
        private QuizService service = new QuizService();

        public ActionResult Mcq(string lang, string id)
        {
            var data = service.GetQuiz(id, lang);
            return View(data);
        }

        [HttpPost]
        public ActionResult Submit(VMTestSubmit obj)
        {
            var successResponse = new { success = true, redirect_url = "/home/" };// for success return this object
            var errorsResponse = new { errors = "" };// for error return this object
            return Json(successResponse, JsonRequestBehavior.AllowGet);
        }
    }
}
