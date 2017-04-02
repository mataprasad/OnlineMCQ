using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Service
{
    public class AccountService
    {
        private CommonService _commonService = null;

        public AccountService(CommonService commonService)
        {
            _commonService = commonService;
        }
    }
}