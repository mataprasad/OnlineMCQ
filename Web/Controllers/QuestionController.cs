using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;
using System.IO;

namespace Web.Controllers
{
    [Authorize(Roles = "SystemAdministrator,CompanyAdmin")]
    public class QuestionController : Web.Helper.AdminBaseController
    {
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

        [HttpPost]
        public ActionResult index(string id)
        {
            var quiz = GetQuiz(id);
            _db.QuestionDbFileName = Path.Combine(CommonService.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            var data = _db.GetAllQuestions();
            ViewBag.Questions = data;
            return View("index");
        }

        public ActionResult list(string query = null)
        {
            var data = new List<Question>();

            if (!String.IsNullOrWhiteSpace(query))
            {
                data = _db.GetAllQuestions(query);
            }
            else
            {
                data = _db.GetAllQuestions();
            }

            return new JsonNetResult(new { aaData = data });
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult add(Question obj)
        {
            var quiz = GetQuiz(obj.QUIZ_ID);
            _db.QuestionDbFileName = Path.Combine(CommonService.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            
            obj.OPTION_A_ID= Guid.NewGuid().ToString().ToLower();
            obj.OPTION_B_ID= Guid.NewGuid().ToString().ToLower();
            obj.OPTION_C_ID= Guid.NewGuid().ToString().ToLower();
            obj.OPTION_D_ID= Guid.NewGuid().ToString().ToLower();
            obj.OPTION_E_ID = Guid.NewGuid().ToString().ToLower();
            obj.QUESTION_ID= Guid.NewGuid().ToString().ToLower();
            obj.IS_ACTIVE = true;

            _db.AddQuestion(obj);
            return index(obj.QUIZ_ID);
        }

        [HttpGet]
        public ActionResult add(string id)
        {
            var quiz = GetQuiz(id);
            return View("add");
        }

        public ActionResult edit(string quiz_id,string que_id)
        {
            var quiz = GetQuiz(quiz_id);
            _db.QuestionDbFileName = Path.Combine(CommonService.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            var que = _db.GetQuestion(que_id);
            return View("add", que);
        }

        [HttpPost]
        public ActionResult edit(Question obj)
        {
            var quiz = GetQuiz(obj.QUIZ_ID);
            _db.QuestionDbFileName = Path.Combine(CommonService.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            _db.EditQuestion(obj);
            return index(obj.QUIZ_ID);
        }

        [HttpPost]
        public ActionResult delete(Question obj)
        {
            var quiz = GetQuiz(obj.QUIZ_ID);
            _db.QuestionDbFileName = Path.Combine(CommonService.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            _db.DeleteQuestion(obj.QUESTION_ID);
            return index(obj.QUIZ_ID);
        }
    }
}

