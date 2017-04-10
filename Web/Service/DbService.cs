using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Helper;
using Web.Models;

namespace Web.Service
{
    public class DbService
    {
        private string company = string.Empty;
        private CommonService commonService = null;

        public DbService(CommonService commonService, string company)
        {
            this.commonService = commonService;
            this.company = company;
        }

        public string QuestionDbFileName { get; set; }

        #region Company

        public List<Company> GetAllCompanies(string query)
        {
            var data = new List<Company>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Company>(SQL.SelectAllCompanyLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public List<Company> GetAllCompanies()
        {
            var data = new List<Company>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Company>(SQL.SelectAllCompany).ToList();
            }
            return data;
        }

        public Company GetCompany(string id)
        {
            var data = new Company();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Company>(SQL.SelectCompanyByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Company AddCompany(Company obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Company>(SQL.InsertCompany + "; " + SQL.SelectCompanyByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Company EditCompany(Company obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Company>(SQL.UpdateCompany + " " + SQL.SelectCompanyByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteCompany(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteCompany, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Student

        public List<Student> GetAllStudents(bool isSysAdmin = false)
        {
            var data = new List<Student>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (isSysAdmin)
                {
                    data = db.GetQueryData<Student>(SQL.SelectAllStudentADMIN).ToList();
                }
                else
                {
                    data = db.GetQueryData<Student>(SQL.SelectAllStudent).ToList();
                }
            }
            return data;
        }

        public List<Student> GetAllStudents(string query, bool isSysAdmin = false)
        {
            var data = new List<Student>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (isSysAdmin)
                {
                    data = db.GetQueryData<Student>(SQL.SelectAllStudentLikeADMIN, new { Term = "%" + query + "%" }).ToList();
                }
                else
                {
                    data = db.GetQueryData<Student>(SQL.SelectAllStudentLike, new { Term = "%" + query + "%" }).ToList();
                }
            }
            return data;
        }

        public Student GetStudent(string id)
        {
            var data = new Student();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Student>(SQL.SelectStudentByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Student AddStudent(Student obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Student>(SQL.InsertStudent + "; " + SQL.SelectStudentByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Student EditStudent(Student obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Student>(SQL.UpdateStudent + "; " + SQL.SelectStudentByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteStudent(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteStudent, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Question

        public List<Question> GetAllQuestions()
        {
            var data = new List<Question>();
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                data = db.GetQueryData<Question>(SQL.SelectAllQuestion).ToList();
            }
            return data;
        }

        public List<Question> GetAllQuestions(string query)
        {
            var data = new List<Question>();
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                data = db.GetQueryData<Question>(SQL.SelectAllQuestionLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public Question GetQuestion(string id)
        {
            var data = new Question();
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                data = db.GetQueryData<Question>(SQL.SelectQuestionByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Question AddQuestion(Question obj)
        {
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                obj = db.GetQueryData<Question>(SQL.InsertQuestion + "; " + SQL.SelectQuestionByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Question EditQuestion(Question obj)
        {
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                obj = db.GetQueryData<Question>(SQL.UpdateQuestion + "; " + SQL.SelectQuestionByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteQuestion(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(this.QuestionDbFileName))
            {
                if (db.Execute(SQL.SoftDeleteQuestion, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Batch

        public List<Batch> GetAllBatches()
        {
            var data = new List<Batch>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Batch>(SQL.SelectAllBatch).ToList();
            }
            return data;
        }

        public List<Batch> GetAllBatches(string query)
        {
            var data = new List<Batch>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Batch>(SQL.SelectAllBatchLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public Batch GetBatch(string id)
        {
            var data = new Batch();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Batch>(SQL.SelectBatchByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Batch AddBatch(Batch obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Batch>(SQL.InsertBatch + "; " + SQL.SelectBatchByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Batch EditBatch(Batch obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Batch>(SQL.UpdateBatch + "; " + SQL.SelectBatchByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteBatch(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteBatch, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Quiz

        public List<Quiz> GetAllQuizzes()
        {
            var data = new List<Quiz>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Quiz>(SQL.SelectAllQuiz).ToList();
            }
            return data;
        }

        public List<Quiz> GetAllQuizzes(string query)
        {
            var data = new List<Quiz>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Quiz>(SQL.SelectAllQuizLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public Quiz GetQuiz(string id)
        {
            var data = new Quiz();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Quiz>(SQL.SelectQuizByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Quiz AddQuiz(Quiz obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Quiz>(SQL.InsertQuiz + "; " + SQL.SelectQuizByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Quiz EditQuiz(Quiz obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Quiz>(SQL.UpdateQuiz + "; " + SQL.SelectQuizByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteQuiz(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteQuiz, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region BatchQuizMap

        public List<BatchQuizMap> GetAllBatchQuizMappings()
        {
            var data = new List<BatchQuizMap>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchQuizMap>(SQL.SelectAllBatchQuizMap).ToList();
            }
            return data;
        }

        public List<BatchQuizMap> GetAllBatchQuizMappings(string query)
        {
            var data = new List<BatchQuizMap>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchQuizMap>(SQL.SelectAllBatchQuizMapLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public BatchQuizMap GetBatchQuizMapping(string id)
        {
            var data = new BatchQuizMap();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchQuizMap>(SQL.SelectBatchQuizMapByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public BatchQuizMap AddBatchQuizMapping(BatchQuizMap obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<BatchQuizMap>(SQL.InsertBatchQuizMap + "; " + SQL.SelectBatchQuizMapByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public BatchQuizMap EditBatchQuizMapping(BatchQuizMap obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<BatchQuizMap>(SQL.UpdateBatchQuizMap + "; " + SQL.SelectBatchQuizMapByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteBatchQuizMapping(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteBatchQuizMap, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region BatchUserMap

        public List<BatchUserMap> GetAllBatchUserMappings()
        {
            var data = new List<BatchUserMap>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchUserMap>(SQL.SelectAllBatchUserMap).ToList();
            }
            return data;
        }

        public List<BatchUserMap> GetAllBatchUserMappings(string query)
        {
            var data = new List<BatchUserMap>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchUserMap>(SQL.SelectAllBatchUserMapLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public BatchUserMap GetBatchUserMapping(string id)
        {
            var data = new BatchUserMap();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<BatchUserMap>(SQL.SelectBatchUserMapByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public BatchUserMap AddBatchUserMapping(BatchUserMap obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<BatchUserMap>(SQL.InsertBatchUserMap + "; " + SQL.SelectBatchUserMapByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public BatchUserMap EditBatchUserMapping(BatchUserMap obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<BatchUserMap>(SQL.UpdateBatchUserMap + "; " + SQL.SelectBatchUserMapByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteBatchUserMapping(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteBatchUserMap, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Attempt

        public List<Attempt> GetAllAttempts()
        {
            var data = new List<Attempt>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Attempt>(SQL.SelectAllAttempt).ToList();
            }
            return data;
        }

        public List<Attempt> GetAllAttempts(string query)
        {
            var data = new List<Attempt>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Attempt>(SQL.SelectAllAttemptLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public Attempt GetAttempt(string id)
        {
            var data = new Attempt();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Attempt>(SQL.SelectAttemptByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Attempt AddAttempt(Attempt obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Attempt>(SQL.InsertAttempt + "; " + SQL.SelectAttemptByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Attempt EditAttempt(Attempt obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Attempt>(SQL.UpdateAttempt + "; " + SQL.SelectAttemptByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteAttempt(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteAttempt, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region AttemptDetail

        public List<AttemptDetail> GetAllAttemptDetails()
        {
            var data = new List<AttemptDetail>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<AttemptDetail>(SQL.SelectAllAttemptDetail).ToList();
            }
            return data;
        }

        public List<AttemptDetail> GetAllAttemptDetails(string query)
        {
            var data = new List<AttemptDetail>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<AttemptDetail>(SQL.SelectAllAttemptDetailLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public AttemptDetail GetAttemptDetail(string id)
        {
            var data = new AttemptDetail();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<AttemptDetail>(SQL.SelectAttemptDetailByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public AttemptDetail AddAttemptDetail(AttemptDetail obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<AttemptDetail>(SQL.InsertAttemptDetail + "; " + SQL.SelectAttemptDetailByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public AttemptDetail EditAttemptDetail(AttemptDetail obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<AttemptDetail>(SQL.UpdateAttemptDetail + "; " + SQL.SelectAttemptDetailByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteAttemptDetail(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteAttemptDetail, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}