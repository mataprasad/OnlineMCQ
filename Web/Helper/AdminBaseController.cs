using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Filters;
using Web.Models;

namespace Web.Helper
{
    //[Authorize]
    //[Trace]
    //[Error]
    public class AdminBaseController : Controller, IAppContext
    {
        private IAppContext _appContext = null;
        public AdminBaseController()
        {
            _appContext = ObjectFactory.CreateAppContext();
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
