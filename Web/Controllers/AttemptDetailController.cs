using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    public class AttemptDetailController : Web.Helper.AdminBaseController
    {
        private Biz _db = new Biz();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult list(string query = null)
        {
            var data = _db.GetAllAttemptDetails();
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
        public ActionResult add(AttemptDetail obj)
        {
            _db.AddAttemptDetail(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetAttemptDetail(id));
        }

        [HttpPost]
        public ActionResult edit(AttemptDetail obj)
        {
            _db.EditAttemptDetail(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteAttemptDetail(id);
            return RedirectToAction("index");
        }
    }
}

