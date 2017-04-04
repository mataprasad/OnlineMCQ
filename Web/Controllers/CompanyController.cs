using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Helper;

namespace Web.Controllers
{
    public class CompanyController : Web.Helper.AdminBaseController
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
            var data = new List<Company>();
            if (!String.IsNullOrWhiteSpace(query))
            {
                data = _db.GetAllCompanies(query);
            }
            else
            {
                data = _db.GetAllCompanies();
            }
            return new JsonNetResult(new { aaData = data });
        }

        [HttpPost]
        public ActionResult add(Company obj)
        {
            obj.ID = Guid.NewGuid().ToString().ToLower();
            obj.CreatedBy = LoggedUserID;
            obj.CreationDate = Utility.GetCurrentDateInt();
            obj.CreationTime = Utility.GetCurrentTimeInt();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.AddCompany(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetCompany(id));
        }

        [HttpPost]
        public ActionResult edit(Company obj)
        {
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.EditCompany(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteCompany(id);
            return RedirectToAction("index");
        }
    }
}

