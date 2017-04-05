using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    public class MessageService: ServiceBase
    {
        public string EmailMessage { get; set; }
        public string EmailSubject { get; set; }
        public List<string> EmailToList { get; set; }
        
        public string SmsMessage { get; set; }
        public List<string> SmsToList { get; set; }
         
        public void Send()
        {
            if (Web.Helper.Common.EmailEnabled)
            {
                SendEmail();
            }

            if (Web.Helper.Common.SmsEnabled)
            {
                SendSms();
            }
        }

        private void SendSms()
        {

        }

        private void SendEmail()
        {

        }
    }
}