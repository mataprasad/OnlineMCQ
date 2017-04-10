using Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Data;
using Web.Data.SQLite;
using System.Data;
using System.IO;
using Web.Helper;
using Web.Models;

namespace Web.Service
{
    public class QuizService
    {
        private IDbAccess _db = null;
        private CommonService _util = CommonService.Instance;
        private string _questionDbFileName = string.Empty;
        private Quiz quiz = null;

        public QuizService(Quiz quiz)
        {
            _questionDbFileName = Path.Combine(_util.GetSQLiteDbFileDirectoryBasePath(), quiz.QuestionDbFile);
            _db = ObjectFactory.CreateDbContext(_questionDbFileName);
            this.quiz = quiz;
        }

        public VMTestPage GetQuizData(string language = "en", string attemptId = "")
        {
            bool isHindi = false;

            if ("hi".Equals(language, StringComparison.OrdinalIgnoreCase))
            {
                isHindi = true;
            }

            var testData = _db.GetAllQuestions(_questionDbFileName);

            VMTestPage data = new VMTestPage();
            data.AttemptId = attemptId;
            data.QuizId = quiz.ID;
            data.Sections = new List<VMSection>();

            var sections = testData.Select(P => { P.SECTION_NAME = P.SECTION_NAME.ToUpper(); return P; }).GroupBy(P => P.SECTION_NAME).Select(P => P).ToList();

            int sectionSeq = 0;

            foreach (var item in sections)
            {
                VMSection section = new VMSection();
                section.Id = Guid.NewGuid().ToString();
                section.Name = item.Key;
                section.SeqNo = sectionSeq;
                section.QuestionCount = item.Count();
                section.Questions = new List<VMQuestion>();

                int questionSeq = 0;

                foreach (var item1 in item.Cast<McqQuestion>().ToList())
                {
                    VMQuestion question = new VMQuestion();
                    question.HasMultipleCorrectAnswer = false;
                    question.HasParagraph = false;
                    question.Id = item1.QUESTION_ID;
                    question.Paragraph = null;
                    question.ParagraphId = Guid.Empty.ToString();
                    question.SeqNo = questionSeq;

                    if (isHindi)
                    {
                        question.Text = item1.QUESTION_TEXT_HI;
                        question.Options = new List<VMOption>();
                        question.Options.Add(new VMOption() { Id = item1.OPTION_A_ID, IsCorrect = false, SeqNo = 0, Text = item1.OPTION_A_HI });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_B_ID, IsCorrect = false, SeqNo = 1, Text = item1.OPTION_B_HI });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_C_ID, IsCorrect = false, SeqNo = 2, Text = item1.OPTION_C_HI });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_D_ID, IsCorrect = false, SeqNo = 3, Text = item1.OPTION_D_HI });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_E_ID, IsCorrect = false, SeqNo = 4, Text = item1.OPTION_E_HI });
                    }
                    else
                    {
                        question.Text = item1.QUESTION_TEXT_EN;
                        question.Options = new List<VMOption>();
                        question.Options.Add(new VMOption() { Id = item1.OPTION_A_ID, IsCorrect = false, SeqNo = 0, Text = item1.OPTION_A_EN });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_B_ID, IsCorrect = false, SeqNo = 1, Text = item1.OPTION_B_EN });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_C_ID, IsCorrect = false, SeqNo = 2, Text = item1.OPTION_C_EN });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_D_ID, IsCorrect = false, SeqNo = 3, Text = item1.OPTION_D_EN });
                        question.Options.Add(new VMOption() { Id = item1.OPTION_E_ID, IsCorrect = false, SeqNo = 4, Text = item1.OPTION_E_EN });
                    }

                    if (quiz.ShuffleOptions)
                    {
                        question.Options = question.Options.OrderBy(P => Guid.NewGuid()).ToList();
                    }

                    section.Questions.Add(question);
                    questionSeq++;
                }
                if (quiz.ShuffleQuestions)
                {
                    section.Questions = section.Questions.OrderBy(P => Guid.NewGuid()).ToList();
                }
                data.Sections.Add(section);
                sectionSeq++;
            }

            return data;
        }

    }
}