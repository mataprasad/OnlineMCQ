using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    public class AttemptController : Web.Helper.AdminBaseController
    {
        private Biz _db = new Biz();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult list(string query = null)
        {
            var data = _db.GetAllAttempts();
            if (!String.IsNullOrWhiteSpace(query))
            {
                return new JsonNetResult(new { aaData = data.Where(P => true).ToList() });
            }
            else
            {
                return new JsonNetResult(new { aaData = data.ToList() });
            }
        }

        [HttpPost]
        public ActionResult add(Attempt obj)
        {
            _db.AddAttempt(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetAttempt(id));
        }

        [HttpPost]
        public ActionResult edit(Attempt obj)
        {
            _db.EditAttempt(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.GetAttempt(id);
            return RedirectToAction("index");
        }
    }
}

