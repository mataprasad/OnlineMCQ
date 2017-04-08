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

        public List<Question> GetAllQuestions()
        {
            var data = new List<Question>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Question>(SQL.SelectAllQuestion).ToList();
            }
            return data;
        }

        public List<Question> GetAllQuestions(string query)
        {
            var data = new List<Question>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Question>(SQL.SelectAllQuestionLike, new { Term = "%" + query + "%" }).ToList();
            }
            return data;
        }

        public Question GetQuestion(string id)
        {
            var data = new Question();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Question>(SQL.SelectQuizByID, new { ID = id }).FirstOrDefault();
            }
            return data;
        }

        public Question AddQuestion(Question obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Question>(SQL.InsertQuestion + "; " + SQL.SelectQuizByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public Question EditQuestion(Question obj)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                obj = db.GetQueryData<Question>(SQL.UpdateQuestion + "; " + SQL.SelectQuestionByID, obj).FirstOrDefault();
            }
            return obj;
        }

        public bool DeleteQuestion(string id)
        {
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                if (db.Execute(SQL.SoftDeleteQuestion, new { ID = id }) > 0)
                {
                    return true;
                }
            }
            return false;
        }

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
    }
}