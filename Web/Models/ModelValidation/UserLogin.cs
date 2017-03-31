using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    [MetadataType(typeof(UserLoginMetaData))]
    public partial class UserLogin
    {
    }
    public class UserLoginMetaData
    {
        [Required]
        public Int32 ID { get; set; }
    }
}