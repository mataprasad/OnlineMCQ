﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public class Common
    {
        public const string DEFAULT_USER = "Guest";
        public enum ApplicationRole
        {
            SystemAdministrator,
            Administrator,
            CasualUser,
            Guest,
            CompanyAdmin,
            Student
        }
        public enum SessionKey
        {
            LOGGED_USER
        }

        public const string ApplicationName = "Online-MCQ";
    }
    public class MembershipContant
    {
        public const string CONNECTION_STRING_NAME = "MembershipConnection";
        public const string USER_TABLE_NAME = "UserLogin";
        public const string USER_ID_COLUMN = "ID";
        public const string USER_NAME_COLUMN = "UserName";
        public const bool AUTO_CREATE_TABLES = true;
    }
}