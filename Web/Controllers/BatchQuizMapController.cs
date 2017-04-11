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
    public class BatchQuizMapController : Web.Helper.AdminBaseController
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

        public ActionResult list(string id, string query = null)
        {
            var data = new List<BatchQuizMap>();
            if (!String.IsNullOrWhiteSpace(query))
            {
                return new JsonNetResult(new { aaData = data.Where(P => true).ToList() });
            }
            else
            {
                data = _db.GetAllBatchQuizMappings();
            }

            return new JsonNetResult(new { aaData = data });
        }

        [HttpPost]
        public ActionResult add(BatchQuizMap obj)
        {
            obj.ID = Guid.NewGuid().ToString().ToLower();
            obj.CompanyID = this.Company.ToLower();
            obj.CreatedBy = LoggedUserID;
            obj.CreationDate = Utility.GetCurrentDateInt();
            obj.CreationTime = Utility.GetCurrentTimeInt();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.AddBatchQuizMapping(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetBatchQuizMapping(id));
        }

        [HttpPost]
        public ActionResult edit(BatchQuizMap obj)
        {
            obj.CompanyID = this.Company.ToLower();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.EditBatchQuizMapping(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteBatchQuizMapping(id);
            return RedirectToAction("index");
        }
    }
}

