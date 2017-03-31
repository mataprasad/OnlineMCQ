using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    public class StudentController : Web.Helper.AdminBaseController
    {
        private Biz _db = new Biz();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult list(string query = null)
        {
            var data = _db.GetAllStudents();
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
        public ActionResult add(Student obj)
        {
            _db.AddStudent(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetStudent(id));
        }

        [HttpPost]
        public ActionResult edit(Student obj)
        {
            _db.EditStudent(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteStudent(_db.GetStudent(id));
            return RedirectToAction("index");
        }
    }
}

