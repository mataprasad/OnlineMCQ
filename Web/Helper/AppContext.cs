using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Web.Models;

namespace Web.Helper
{
    public interface IAppContext
    {
        UserLogin LoggedUser { get; }
        String LoggedUserScreenName { get; }
        Int32 LoggedUserID { get; }
    }
    public class AppContext : IAppContext
    {
        private UserLogin _loggedUser = null;
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

        public Int32 LoggedUserID
        {
            get
            {
                if (LoggedUser != null)
                {
                    return LoggedUser.ID;
                }
                else
                {
                    return -1;
                }
            }
        }
    }

    public static class ObjectFactory
    {
        public static IAppContext CreateAppContext()
        {
            return new AppContext();
        }
    }
}