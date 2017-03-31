using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Service;

namespace Web.Controllers
{
    public class TestController : Web.Helper.AdminBaseController
    {
        private QuizService service = new QuizService();

        public ActionResult Mcq(string lang, string id)
        {
            var data = service.GetQuiz(id, lang);
            return View(data);
        }
    }
}
