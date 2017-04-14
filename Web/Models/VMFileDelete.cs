using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Web.Helper.Common;

namespace Web.Models
{
    public class VMFileDelete
    {
        public FileType FileType { get; set; }
        public string FileName { get; set; }
    }
}