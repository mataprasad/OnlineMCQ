using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Helper;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    [Authorize(Roles = "SystemAdministrator,CompanyAdmin,Student")]
    public class TestController : Web.Helper.AdminBaseController
    {
        private QuizService service = null;

        private Biz _db;

        private Quiz GetQuiz(string id)
        {
            Quiz quiz = null;
            var ecryptedQuizStr = Request["csrfmiddlewaretoken"];
            if (!string.IsNullOrWhiteSpace(ecryptedQuizStr))
            {
                quiz = Utility.DeserializeFromXml<Quiz>(Utility.Decrypt(ecryptedQuizStr));
            }

            if (quiz == null || string.IsNullOrWhiteSpace(quiz.ID))
            {
                quiz = _db.GetQuiz(id);
            }

            ViewBag.csrfmiddlewaretoken = Utility.Encrypt(Utility.SerializeToXml<Quiz>(quiz));
            ViewBag.Quiz = quiz;
            return quiz;
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _db = this.InitBiz();
        }


        public ActionResult Mcq(string id)
        {
            var quiz = GetQuiz(id);
            if (quiz == null || quiz.IsPublished == false)
            {
                return Content("Invalid exam.");
            }


            return View("index");
        }

        [HttpPost]
        public ActionResult exam(VMStartExam obj)
        {
            var quiz = GetQuiz(obj.QuizId);
            if (quiz == null || quiz.IsPublished == false)
            {
                return Content("Invalid exam.");
            }
            if (quiz != null && quiz.IsOnlyInClass && quiz.Otp != obj.Otp)
            {
                return Content("Invalid OTP.");
            }
            var lang = obj.Lang;
            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = "en";
            }
            service = new QuizService(quiz);
            var attempt = _db.GetAttempt(quiz.ID, LoggedUserID);
            if (attempt != null && !quiz.AllowMultipleAttempts)
            {
                return Content("You are allow to attempt this exam only once.");
            }

            Attempt objAttempt = new Attempt();
            objAttempt.BatchID = null;
            objAttempt.CompanyID = Company;
            objAttempt.CreatedBy = LoggedUserID;
            objAttempt.CreationDate = Utility.GetCurrentDateInt();
            objAttempt.CreationTime = Utility.GetCurrentTimeInt();
            objAttempt.ID = Guid.NewGuid().ToString().ToLower();
            objAttempt.IsActive = true;
            objAttempt.ModificationDate = Utility.GetCurrentDateInt();
            objAttempt.ModificationTime = Utility.GetCurrentTimeInt();
            objAttempt.ModifiedBy = LoggedUserID;
            objAttempt.OtherDetails = null;
            objAttempt.QuizID = quiz.ID;
            objAttempt.UserID = LoggedUserID;

            objAttempt = _db.AddAttempt(objAttempt);

            var data = service.GetQuizData(lang.ToLower(), objAttempt.ID);
            return View("mcq", data);
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
