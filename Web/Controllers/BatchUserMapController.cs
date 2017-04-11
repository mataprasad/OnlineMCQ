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
    public class BatchUserMapController : Web.Helper.AdminBaseController
    {
        private Biz _db;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _db = this.InitBiz();
        }

        public ActionResult index(string id)
        {
            ViewBag.ID = id;
            return View();
        }

        public ActionResult list(string id, string query = null)
        {
            var data = new List<BatchUserMap>();
            if (!String.IsNullOrWhiteSpace(query))
            {
                data = _db.GetAllBatchUserMappings(id,query);
            }
            else
            {
                data = _db.GetAllBatchUserMappings(id);
            }

            return new JsonNetResult(new { aaData = data });
        }

        [HttpPost]
        public ActionResult add(BatchUserMap obj)
        {
            obj.ID = Guid.NewGuid().ToString().ToLower();
            obj.CompanyID = this.Company.ToLower();
            obj.CreatedBy = LoggedUserID;
            obj.CreationDate = Utility.GetCurrentDateInt();
            obj.CreationTime = Utility.GetCurrentTimeInt();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.AddBatchUserMapping(obj);
            return RedirectToAction("index");
        }

        public ActionResult edit(string id)
        {
            return new JsonNetResult(_db.GetBatchUserMapping(id));
        }

        [HttpPost]
        public ActionResult edit(BatchUserMap obj)
        {
            obj.CompanyID = this.Company.ToLower();
            obj.ModificationDate = Utility.GetCurrentDateInt();
            obj.ModificationTime = Utility.GetCurrentTimeInt();
            obj.ModifiedBy = LoggedUserID;
            _db.EditBatchUserMapping(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteBatchUserMapping(id);
            return RedirectToAction("index");
        }
    }
}

