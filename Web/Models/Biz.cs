using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Service;

namespace Web.Models
{
    public class Biz
    {
        private DbService _db = null;
        private CommonService commonService = null;

        public Biz() { }

        public Biz(CommonService commonService, string company)
        {
            _db = new DbService(commonService, company);
            this.commonService = commonService;
        }

        public string QuestionDbFileName
        {
            set
            {
                _db.QuestionDbFileName = value;
            }
        }

        #region Quiz Mathods

        public List<Quiz> GetAllQuizzes()
        {
            return _db.GetAllQuizzes();
        }

        public List<Quiz> GetAllQuizzes(string query)
        {
            return _db.GetAllQuizzes(query);
        }

        public Quiz GetQuiz(string id)
        {
            return _db.GetQuiz(id);
        }

        public Quiz AddQuiz(Quiz obj)
        {
            obj = _db.AddQuiz(obj);
            var questionDbFile = commonService.CreateQuestionSQLiteDbFileForQuiz(obj.ID.ToLower());
            obj.QuestionDbFile = questionDbFile;
            obj = _db.EditQuiz(obj);
            return obj;
        }

        public Quiz EditQuiz(Quiz obj)
        {
            return _db.EditQuiz(obj);
        }

        public bool DeleteQuiz(string id)
        {
            return _db.DeleteQuiz(id);
        }

        #endregion
        #region BatchQuizMap Mathods

        public List<BatchQuizMap> GetAllBatchQuizMappings()
        {
            return _db.GetAllBatchQuizMappings();
        }

        public List<BatchQuizMap> GetAllBatchQuizMappings(string query)
        {
            return _db.GetAllBatchQuizMappings(query);
        }

        public BatchQuizMap GetBatchQuizMapping(string id)
        {
            return _db.GetBatchQuizMapping(id);
        }

        public BatchQuizMap AddBatchQuizMapping(BatchQuizMap obj)
        {
            return _db.AddBatchQuizMapping(obj);
        }

        public BatchQuizMap EditBatchQuizMapping(BatchQuizMap obj)
        {
            return _db.EditBatchQuizMapping(obj);
        }

        public bool DeleteBatchQuizMapping(string id)
        {
            return _db.DeleteBatchQuizMapping(id);
        }

        #endregion
        #region BatchUserMap Mathods

        public List<BatchUserMap> GetAllBatchUserMappings(string id)
        {
            return _db.GetAllBatchUserMappings(id);
        }

        public List<BatchUserMap> GetAllBatchUserMappings(string id,string query)
        {
            return _db.GetAllBatchUserMappings(id,query);
        }

        public BatchUserMap GetBatchUserMapping(string id)
        {
            return _db.GetBatchUserMapping(id);
        }

        public BatchUserMap AddBatchUserMapping(BatchUserMap obj)
        {
            return _db.AddBatchUserMapping(obj);
        }

        public BatchUserMap EditBatchUserMapping(BatchUserMap obj)
        {
            return _db.EditBatchUserMapping(obj);
        }

        public bool DeleteBatchUserMapping(string id)
        {
            return _db.DeleteBatchUserMapping(id);
        }

        #endregion
        #region Attempt Mathods

        public List<Attempt> GetAllAttempts()
        {
            return _db.GetAllAttempts();
        }

        public List<Attempt> GetAllAttempts(string query)
        {
            return _db.GetAllAttempts(query);
        }

        public Attempt GetAttempt(string id)
        {
            return _db.GetAttempt(id);
        }

        public Attempt GetAttempt(string quizId, string userId)
        {
            return _db.GetAttempt(quizId, userId);
        }

        public Attempt AddAttempt(Attempt obj)
        {
            return _db.AddAttempt(obj);
        }

        public Attempt EditAttempt(Attempt obj)
        {
            return _db.EditAttempt(obj);
        }

        public bool DeleteAttempt(string id)
        {
            return _db.DeleteAttempt(id);
        }

        #endregion
        #region AttemptDetail Mathods

        public List<AttemptDetail> GetAllAttemptDetails()
        {
            return _db.GetAllAttemptDetails();
        }

        public List<AttemptDetail> GetAllAttemptDetails(string query)
        {
            return _db.GetAllAttemptDetails(query);
        }

        public AttemptDetail GetAttemptDetail(string id)
        {
            return _db.GetAttemptDetail(id);
        }

        public AttemptDetail AddAttemptDetail(AttemptDetail obj)
        {
            return _db.AddAttemptDetail(obj);
        }

        public AttemptDetail EditAttemptDetail(AttemptDetail obj)
        {
            return _db.EditAttemptDetail(obj);
        }

        public bool DeleteAttemptDetail(string id)
        {
            return _db.DeleteAttemptDetail(id);
        }

        #endregion
        #region UserLogin Mathods

        public IQueryable<UserLogin> GetAllUserLogins()
        {
            return null;// _db.UserLogins.AsQueryable();
        }

        public UserLogin GetUserLogin(object id)
        {
            return null;// _db.UserLogins.Find(id);
        }

        public UserLogin AddUserLogin(UserLogin obj)
        {
            //_db.UserLogins.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public UserLogin EditUserLogin(UserLogin obj)
        {
            //_db.Entry<UserLogin>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public UserLogin DeleteUserLogin(UserLogin obj)
        {
            //_db.UserLogins.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region Company Mathods

        public List<Company> GetAllCompanies()
        {
            return _db.GetAllCompanies();
        }

        public List<Company> GetAllCompanies(string query)
        {
            return _db.GetAllCompanies(query);
        }

        public Company GetCompany(string id)
        {
            return _db.GetCompany(id);
        }

        public Company AddCompany(Company obj)
        {
            obj = _db.AddCompany(obj);
            commonService.CreatNewCompanyDb(obj.ID);
            return obj;
        }

        public Company EditCompany(Company obj)
        {
            return _db.EditCompany(obj);
        }

        public bool DeleteCompany(string id)
        {
            return _db.DeleteCompany(id);
        }

        #endregion
        #region Batch Mathods

        public List<Batch> GetAllBatches()
        {
            return _db.GetAllBatches();
        }

        public List<Batch> GetAllBatches(string query)
        {
            return _db.GetAllBatches(query);
        }

        public Batch GetBatch(string id)
        {
            return _db.GetBatch(id);
        }

        public Batch AddBatch(Batch obj)
        {
            return _db.AddBatch(obj);
        }

        public Batch EditBatch(Batch obj)
        {
            return _db.EditBatch(obj);
        }

        public bool DeleteBatch(string id)
        {
            return _db.DeleteBatch(id);
        }

        #endregion
        #region Student Mathods

        public List<Student> GetAllStudents(bool isSysAdmin = false)
        {
            return _db.GetAllStudents(isSysAdmin);
        }

        public List<Student> GetAllStudents(string query, bool isSysAdmin = false)
        {
            return _db.GetAllStudents(query, isSysAdmin);
        }

        public Student GetStudent(string id)
        {
            return _db.GetStudent(id);
        }

        public Student AddStudent(Student obj)
        {
            return _db.AddStudent(obj);
        }

        public Student EditStudent(Student obj)
        {
            return _db.EditStudent(obj);
        }

        public bool DeleteStudent(string id)
        {
            return _db.DeleteStudent(id);
        }

        #endregion
        #region Question Mathods

        public List<Question> GetAllQuestions()
        {
            return _db.GetAllQuestions();
        }

        public List<Question> GetAllQuestions(string query)
        {
            return _db.GetAllQuestions(query);
        }

        public Question GetQuestion(string id)
        {
            return _db.GetQuestion(id);
        }

        public Question AddQuestion(Question obj)
        {
            return _db.AddQuestion(obj);
        }

        public Question EditQuestion(Question obj)
        {
            return _db.EditQuestion(obj);
        }

        public bool DeleteQuestion(string id)
        {
            return _db.DeleteQuestion(id);
        }

        #endregion

    }
}
