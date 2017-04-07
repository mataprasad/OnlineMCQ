using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;
using WebMatrix.WebData;

namespace Web.Helper
{
    public class AppMembershipProvider : SimpleMembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            var appContext = AppContext.GetCurrentController();
            if (appContext != null && !string.IsNullOrWhiteSpace(appContext.Company) && appContext.AccountService != null)
            {
                var loggedUser = appContext.AccountService.LoginUser(username, password, appContext.Company);
                if (loggedUser != null && !string.IsNullOrWhiteSpace(loggedUser.ID))
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class AppRoleProvider : SimpleRoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            var loggedUser = (UserLogin)HttpContext.Current.Session[Common.SessionKey.LOGGED_USER.ToKey()];
            if (loggedUser != null)
            {
                return loggedUser.AccessLevel.ToString().Split(',');
            }
            return new List<string>().ToArray();
        }
    }
}