using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public static class SQL
    {
        public const string SelectAllCompany = @"SELECT * FROM COMPANY;";
        public const string CheckCompanyActiveStatus = @"SELECT * FROM Company WHERE ID = @ID AND LicenceTo>= @LicenceTo AND IsActive =1;";

        public const string UserLoginCheck = @"SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,'*' AS AccessLevel FROM Student WHERE Email = @Email AND Password = @Password AND IsActive=1;";

        public const string ChangeUserPassword = @"UPDATE Student set Password=@NewPassword WHERE Email=@Email AND Password=@Password;
                                                   SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,'*' AS AccessLevel FROM Student WHERE Email = @Email AND Password = @NewPassword;";
    }
}