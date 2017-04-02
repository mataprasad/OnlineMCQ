using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Model
{
    public class VMTestPage
    {
        public List<VMSection> Sections { get; set; }

        public static VMTestPage LoadTestData()
        {
            VMTestPage data = new VMTestPage();
            data.AttemptId = Guid.NewGuid().ToString();
            data.QuizId = Guid.NewGuid().ToString();
            data.Sections = new List<VMSection>();

            int queCount = 0;
            Random rd = new Random();
            for (int i = 0; i < 4; i++)
            {
                queCount = rd.Next(10, 20);
                data.Sections.Add(new VMSection()
                {
                    Id = Guid.NewGuid().ToString(),
                    QuestionCount = queCount,
                    Name = "SectionNoX-" + i,
                    Questions = GetTestQuestion("SectionNoX-" + i, i, queCount),
                    SeqNo = i
                });
            }

            return data;
        }

        private static List<VMQuestion> GetTestQuestion(string section, int sectionSeqNo, int totalCount)
        {
            var data = new List<VMQuestion>();

            for (int i = 0; i < totalCount; i++)
            {
                data.Add(new VMQuestion()
                {
                    HasMultipleCorrectAnswer = true,
                    Id = Guid.NewGuid().ToString(),
                    Options = GetTestOptions(section + "__ques" + i),
                    Paragraph = "Paragraph" + Guid.NewGuid().ToString(),
                    ParagraphId = Guid.NewGuid().ToString(),
                    HasParagraph = true,
                    SeqNo = i,
                    Text = section + "__ques" + i,
                });
            }

            return data;
        }

        private static List<VMOption> GetTestOptions(string ques)
        {
            var data = new List<VMOption>();
            for (int i = 0; i < 4; i++)
            {
                data.Add(new VMOption()
                {
                    Id = Guid.NewGuid().ToString(),
                    IsCorrect = true,
                    SeqNo = i,
                    Text = ques + "_OPT" + i,
                });
            }
            return data;
        }

        public string QuizId { get; set; }
        public string AttemptId { get; set; }
    }

    public class VMSection
    {
        public int SeqNo { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public int QuestionCount { get; set; }
        public List<VMQuestion> Questions { get; set; }
    }

    public class VMQuestion
    {
        public int SeqNo { get; set; }
        public string Id { get; set; }
        public string Text { get; set; }
        public string Paragraph { get; set; }
        public string ParagraphId { get; set; }
        public bool HasParagraph { get; set; }
        public bool HasMultipleCorrectAnswer { get; set; }
        public List<VMOption> Options { get; set; }

        public string GetQpActiveCss(int sectionSeqNo)
        {
            if (sectionSeqNo == 0 && this.SeqNo == 0)
            {
                return "active";
            }
            return "";
        }
        public string GetQpQueNoActiveCss(int sectionSeqNo)
        {
            if (sectionSeqNo == 0 && this.SeqNo == 0)
            {
                return "active";
            }
            return "unseen";
        }
    }

    public class VMOption
    {
        public int SeqNo { get; set; }
        public char SeqNoChar
        {
            get
            {
                return (char)(65 + SeqNo);
            }
        }
        public string Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}