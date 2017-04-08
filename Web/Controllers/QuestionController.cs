using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    [Authorize(Roles = "SystemAdministrator,CompanyAdmin")]
    public class QuestionController : Web.Helper.AdminBaseController
    {
        private Biz _db;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _db = this.InitBiz();
        }

        public ActionResult index()
        {
            return View();
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
        public ActionResult add(Question obj)
        {
            _db.AddQuestion(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetQuestion(id));
        }

        [HttpPost]
        public ActionResult edit(Question obj)
        {
            _db.EditQuestion(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteQuestion(id);
            return RedirectToAction("index");
        }
    }
}

