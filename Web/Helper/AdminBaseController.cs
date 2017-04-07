using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Filters;
using Web.Models;
using Web.Service;

namespace Web.Helper
{
    //[Authorize]
    [Trace]
    [Error]
    public class AdminBaseController : Controller, IAppContext
    {
        private CommonService _commonService = CommonService.Instance;
        private AccountService _accountService = null;
        private IAppContext _appContext = null;

        public event Action<string,string> OnComapnyChange;

        public AdminBaseController()
        {
            _appContext = ObjectFactory.CreateAppContext(_commonService);
            _accountService = new AccountService(_commonService);
            this.OnComapnyChange += AdminBaseController_OnComapnyChange;
        }

        private void AdminBaseController_OnComapnyChange(string obj,string companyCode)
        {
            this.Company = obj;
        }

        public Biz InitBiz()
        {
          return new Biz(this.CommonService, this.Company);
        }

        public UserLogin LoggedUser
        {
            get { return _appContext.LoggedUser; }
        }

        public string LoggedUserScreenName
        {
            get { return _appContext.LoggedUserScreenName; }
        }

        public string LoggedUserID
        {
            get { return _appContext.LoggedUserID; }
        }

        public CommonService CommonService
        {
            get
            {
                return _appContext.CommonService;
            }
        }

        public AccountService AccountService
        {
            get
            {
                return _accountService;
            }
        }

        public string Company
        {
            get
            {
                return _appContext.Company;
            }
            set
            {
                _appContext.Company = value;
            }
        }

        public string CompanyCode
        {
            get
            {
                return _appContext.Company;
            }
            set
            {
                _appContext.Company = value;
            }
        }

        public void ChangeComapny(string company,string companyCode)
        {
            if (this.OnComapnyChange != null)
            {
                OnComapnyChange(company, companyCode);
            }
        }
    }
}
