using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Helper
{
    public class AppViewEngine : RazorViewEngine
    {

    }

    public class AppWebView<T> : WebViewPage<T>, IAppContext
    {
        private IAppContext _appContext = null;
        public AppWebView()
        {
            _appContext = ObjectFactory.CreateAppContext();
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
    }
}