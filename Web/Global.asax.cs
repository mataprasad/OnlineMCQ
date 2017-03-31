using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Web.Helper;
using WebMatrix.WebData;

namespace Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new Web.Helper.AppViewEngine());
            //WebSecurity.InitializeDatabaseConnection(
            //    MembershipContant.CONNECTION_STRING_NAME,
            //    MembershipContant.USER_TABLE_NAME,
            //    MembershipContant.USER_ID_COLUMN,
            //    MembershipContant.USER_NAME_COLUMN,
            //    MembershipContant.AUTO_CREATE_TABLES);
            //SetupRoles();
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void SetupRoles()
        {
            foreach (var item in Enum.GetNames(typeof(Web.Helper.Common.ApplicationRole)))
            {
                if (!System.Web.Security.Roles.RoleExists(item))
                {
                    System.Web.Security.Roles.CreateRole(item);
                }
            }
        }
    }
}