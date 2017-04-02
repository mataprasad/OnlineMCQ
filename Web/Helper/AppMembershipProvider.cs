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
            var appContext = AppContext.GetCurrentAppContext();
            return true;
        }
    }
}