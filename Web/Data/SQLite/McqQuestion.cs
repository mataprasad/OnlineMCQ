using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Data.SQLite
{
    public class McqQuestion
    {
        public string QUIZ_ID { get; set; }
        public string QUESTION_ID { get; set; }
        public string SECTION_NAME { get; set; }
        public string QUESTION_TEXT_EN { get; set; }
        public string QUESTION_TEXT_HI { get; set; }
        public string OPTION_A_EN { get; set; }
        public string OPTION_B_EN { get; set; }
        public string OPTION_C_EN { get; set; }
        public string OPTION_D_EN { get; set; }
        public string OPTION_E_EN { get; set; }
        public string OPTION_A_HI { get; set; }
        public string OPTION_B_HI { get; set; }
        public string OPTION_C_HI { get; set; }
        public string OPTION_D_HI { get; set; }
        public string OPTION_E_HI { get; set; }
        public string OPTION_A_ID { get; set; }
        public string OPTION_B_ID { get; set; }
        public string OPTION_C_ID { get; set; }
        public string OPTION_D_ID { get; set; }
        public string OPTION_E_ID { get; set; }
        public string CORRECT_OPTIONS { get; set; }
    }
}