using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    public class ServiceBase
    {
        protected string Company { get; set; }

        public void ValidCompany()
        {
            if (string.IsNullOrWhiteSpace(Company))
            {
                throw new Exception("Please specifiy company."); 
            }
        }

        public void SetCompanyContext(string company)
        {
            this.Company = company;
        }
    }
}