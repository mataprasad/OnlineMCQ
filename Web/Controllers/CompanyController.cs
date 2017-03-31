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
        private Biz _db = new Biz();
        public ActionResult index()
        {
            return View();
        }

        public ActionResult list(string query = null)
        {
            var data = _db.GetAllCompanies();
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
        public ActionResult add(Company obj)
        {
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
            _db.EditCompany(obj);
            return RedirectToAction("index");
        }

        public ActionResult delete(string id)
        {
            _db.DeleteCompany(_db.GetCompany(id));
            return RedirectToAction("index");
        }
    }
}

