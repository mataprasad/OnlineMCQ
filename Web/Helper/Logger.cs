using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public class Logger
    {
        private static Logger _Instance = null;
        private Logger() { }
        public void LogTrace(String txt)
        {
            try
            {

            }
            catch { }
        }
        public void LogError(String txt)
        {
            try
            {

            }
            catch { }
        }

        public void LogException(Exception ex)
        {
            try
            {

            }
            catch { }
        }

        public static Logger Instance {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Logger();
                }
                return _Instance;
            }
        }
    }
}