using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class VMTestSubmit
    {
        public VMTestSubmit()
        {
            questions = new List<VMSubmitQuestion>();
            sections = new List<VMSubmitSection>();
        }

        public string csrfmiddlewaretoken { get; set; }
        public List<VMSubmitQuestion> questions { get; set; }
        public string total_time_spent { get; set; }
        public string test_id { get; set; }
        public string attempt_id { get; set; }
        public List<VMSubmitSection> sections { get; set; }
    }

    public class VMSubmitSection
    {
        public string section_id { get; set; }
        public string time_spent { get; set; }
    }

    public class VMSubmitQuestion
    {
        public VMSubmitQuestion()
        {
            option_ids = new List<string>();
        }

        public string section_id { get; set; }
        public string question_id { get; set; }
        public string topic_id { get; set; }
        public string status { get; set; }
        public List<string> option_ids { get; set; }
        public string time_spent { get; set; }
    }
}