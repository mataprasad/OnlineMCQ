using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Web.Data;
using Web.Data.SQLite;
using Web.Models;
using Web.Service;

namespace Web.Helper
{
    public interface IAppContext
    {
        UserLogin LoggedUser { get; }
        String LoggedUserScreenName { get; }
        string LoggedUserID { get; }
        CommonService CommonService { get; }
        string Company { get; set; }
        string CompanyCode { get; set; }
    }

    public class AppContext : IAppContext
    {
        public const string EXECUTING_CONTROLLER_KEY = @"CurrentExecutingController";

        private UserLogin _loggedUser = null;
        private CommonService _commonService = null;

        public AppContext(CommonService commonService)
        {
            _commonService = commonService;
        }

        public UserLogin LoggedUser
        {
            get
            {
                if (_loggedUser == null)
                {
                    _loggedUser = (UserLogin)HttpContext.Current.Session[Common.SessionKey.LOGGED_USER.ToKey()];                    
                    if (_loggedUser == null)
                    {
                        FormsAuthentication.SignOut();
                        FormsAuthentication.RedirectToLoginPage();
                    }
                }
                return _loggedUser;
            }
        }

        public String LoggedUserScreenName
        {
            get
            {
                if (LoggedUser != null)
                {
                    return LoggedUser.ScreenName;
                }
                else
                {
                    return Common.DEFAULT_USER;
                }
            }
        }

        public string LoggedUserID
        {
            get
            {
                if (LoggedUser != null)
                {
                    return LoggedUser.ID;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        public CommonService CommonService
        {
            get
            {
                return _commonService;
            }
        }

        public string Company
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[Common.SessionKey.COMPANY.ToKey()]);
            }
            set
            {
                HttpContext.Current.Session[Common.SessionKey.COMPANY.ToKey()] = value;
            }
        }

        public string CompanyCode
        {
            get
            {
                return Convert.ToString(HttpContext.Current.Session[Common.SessionKey.COMPANY_CODE.ToKey()]);
            }
            set
            {
                HttpContext.Current.Session[Common.SessionKey.COMPANY_CODE.ToKey()] = value;
            }
        }

        public static IAppContext GetCurrentAppContext()
        {
            AdminBaseController currentController = HttpContext.Current.Items[AppContext.EXECUTING_CONTROLLER_KEY] as AdminBaseController;
            if (currentController != null)
            {
                return currentController as IAppContext;
            }
            return null;
        }

        public static AdminBaseController GetCurrentController()
        {
            return HttpContext.Current.Items[AppContext.EXECUTING_CONTROLLER_KEY] as AdminBaseController;
        }
    }

    public static class ObjectFactory
    {
        public static IAppContext CreateAppContext(CommonService commonService)
        {
            return new AppContext(commonService);
        }

        public static IDbAccess CreateDbContext(string connectionString)
        {
            return new SQLiteHelper(connectionString);
        }
    }
}