using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VMStartExam
    {
        [Required]
        public string Lang { get; set; }
        [Required]
        public string Otp { get; set; }
        [Required]
        public string QuizId { get; set; }
        public string csrfmiddlewaretoken { get; set; }
    }
}