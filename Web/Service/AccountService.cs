using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data.SQLite;
using Web.Helper;
using Web.Models;

namespace Web.Service
{
    public class AccountService : ServiceBase
    {
        private CommonService _commonService = null;

        public AccountService(CommonService commonService)
        {
            _commonService = commonService;
        }

        public UserLogin LoginUser(string email, string password, string companyId)
        {
            UserLogin loggedUser = null;
            if (!_commonService.IsCompanyActive(companyId))
            {
                throw new Exception(String.Format("Selected [{0}] institute has not valid licence.", companyId));
            }

            using (var db = ObjectFactory.CreateDbContext(_commonService.GetCompanyDbFilePath(companyId)))
            {
                loggedUser = db.GetQueryData<UserLogin>(SQL.UserLoginCheck, new { Email = email, Password = password }).FirstOrDefault();
            }

            return loggedUser;
        }

        public bool ChangePassword(string email, string currentPassword, string newPassword)
        {
            ValidCompany();
            using (var db = ObjectFactory.CreateDbContext(_commonService.GetCompanyDbFilePath(this.Company)))
            {
                var obj = db.GetQueryData<UserLogin>(SQL.ChangeUserPassword, new { Email = email, Password = currentPassword, NewPassword = newPassword }).FirstOrDefault();
                if (obj != null && !string.IsNullOrWhiteSpace(obj.ID))
                {
                    return true;
                }
            }
            return false;
        }
    }
}