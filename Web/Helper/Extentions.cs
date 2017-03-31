using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public static class AppExtentions
    {
        public static string ToKey(this Enum obj)
        {
            return obj.ToString().ToUpper();
        }
    }
}