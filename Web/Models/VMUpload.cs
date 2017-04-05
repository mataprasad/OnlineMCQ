using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VMUpload
    {
        [Required(ErrorMessage = "*")]
        public string UploadType { get; set; }
        [Required(ErrorMessage = "*")]
        public HttpPostedFileBase File { get; set; }
    }
}