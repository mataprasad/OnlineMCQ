using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    public class BatchController : Web.Helper.AdminBaseController
    {
        private Biz _db = new Biz();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult list(string query = null)
        {
            var data = _db.GetAllBatches();
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
        public ActionResult add(Batch obj)
        {
            _db.AddBatch(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetBatch(id));
        }

        [HttpPost]
        public ActionResult edit(Batch obj)
        {
            _db.EditBatch(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteBatch(_db.GetBatch(id));
            return RedirectToAction("index");
        }
    }
}

