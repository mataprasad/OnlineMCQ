using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Service;

namespace Web.Helper
{
    public class AppViewEngine : RazorViewEngine
    {

    }

    public class AppWebView<T> : WebViewPage<T>, IAppContext
    {
        private CommonService _commonService = CommonService.Instance;
        private IAppContext _appContext = null;

        public AppWebView()
        {
            if (this.ViewContext == null || !(this.ViewContext.Controller is AdminBaseController))
            {
                _appContext = ObjectFactory.CreateAppContext(_commonService);
            }
            else
            {
                var currentController = this.ViewContext.Controller as AdminBaseController;
                if (currentController != null)
                {
                    _appContext = currentController as IAppContext;
                }
            }
        }

        public override void Execute()
        {

        }

        public UserLogin LoggedUser
        {
            get { return _appContext.LoggedUser; }
        }

        public string LoggedUserScreenName
        {
            get { return _appContext.LoggedUserScreenName; }
        }

        public int LoggedUserID
        {
            get { return _appContext.LoggedUserID; }
        }

        public CommonService CommonService
        {
            get { return _appContext.CommonService; }
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
    }
}