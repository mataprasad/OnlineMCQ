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

namespace Web.Service
{
    public class QuizService
    {
        private IDbAccess _db = null;
        private CommonService _util = CommonService.Instance;
        private string _temporaryDirectoryBasePath = null;

        public QuizService()
        {
            _temporaryDirectoryBasePath = _util.GetTemporaryDirectoryBasePath();
            _db = ObjectFactory.CreateDbContext(@"D:\CodeLib\Mcq.Online\Mcq.Test\bin\DbX.s3db");
        }

        public VMTestPage GetQuiz(string quizId, string language = "en")
        {
            bool isHindi = false;

            if ("hi".Equals(language, StringComparison.OrdinalIgnoreCase))
            {
                isHindi = true;
            }

            var testData = _db.GetAllQuestions();

            VMTestPage data = new VMTestPage();
            data.AttemptId = Guid.NewGuid().ToString();
            data.QuizId = Guid.NewGuid().ToString();
            data.Sections = new List<VMSection>();

            var sections = testData.GroupBy(P => P.SECTION_NAME).Select(P => P).ToList();

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

                    section.Questions.Add(question);
                    questionSeq++;
                }

                data.Sections.Add(section);
                sectionSeq++;
            }

            return data;
        }

        public bool UploadQuizQuestions(string excelFileName)
        {
            DataTable dt = _util.GetDataTableFromExcelSheat(Path.Combine(_temporaryDirectoryBasePath, excelFileName));
            return _db.BulkInsertQuestions(dt);
        }

        public bool CreateQuiz()
        {
            //string newDbFileName = _util.GetRandomSQLiteDbFileName();
            //File.Copy(_util.GetSQLiteQuestionsTemplateDatabaseFile(), Path.Combine(_util.GetSQLiteDbFileDirectoryBasePath(), newDbFileName), true);
            return true;
        }
    }
}