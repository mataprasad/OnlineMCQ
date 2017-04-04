using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public override bool IsUserInRole(string username, string roleName)
        {
            return true;
        }
    }
}