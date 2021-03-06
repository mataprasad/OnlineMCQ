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
    public class StudentController : Web.Helper.AdminBaseController
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
            var data = new List<Student>();
            if (!String.IsNullOrWhiteSpace(query))
            {
                data = _db.GetAllStudents(query, LoggedUser.IsSystemAdministrator);
            }
            else
            {
                data = _db.GetAllStudents(LoggedUser.IsSystemAdministrator);
            }

            return new JsonNetResult(new { aaData = data });
        }

        [HttpPost]
        public ActionResult add(Student obj)
        {
            obj.ID = Guid.NewGuid().ToString().ToLower();
            obj.CompanyID = this.Company.ToLower();
            obj.CreatedBy = LoggedUserID;
            obj.CreationDate = Utility.GetCurrentDateInt();
            obj.CreationTime = Utility.GetCurrentTimeInt();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            obj.Roles = "Student";
            _db.AddStudent(obj);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult edit(string id)
        {
            var obj = _db.GetStudent(id);
            if (obj != null)
            {
                obj.PhotoUrl = ToUserPhotoNonAbsulture(obj.Photo);
            }
            return new JsonNetResult(obj);
        }

        [HttpPost]
        public ActionResult edit(Student obj)
        {
            obj.CompanyID = this.Company.ToLower();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;

            if (!"admin@mail.in".Equals(obj.Email, StringComparison.OrdinalIgnoreCase))
            {
                obj.Roles = "Student";
            }
            _db.EditStudent(obj);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult delete(string id)
        {
            _db.DeleteStudent(id);
            return RedirectToAction("index");
        }
    }
}

