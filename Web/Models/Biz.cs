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

        #region Quiz Mathods

        public List<Quiz> GetAllQuizs()
        {
            return _db.GetAllQuizs();
        }

        public Quiz GetQuiz(object id)
        {
            return null;// _db.Quizs.Find(id);
        }

        public Quiz AddQuiz(Quiz obj)
        {
            //_db.Quizs.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public Quiz EditQuiz(Quiz obj)
        {
            //_db.Entry<Quiz>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public Quiz DeleteQuiz(Quiz obj)
        {
            //_db.Quizs.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region BatchQuizMap Mathods

        public IQueryable<BatchQuizMap> GetAllBatchQuizMaps()
        {
            return null;// _db.BatchQuizMaps.AsQueryable();
        }

        public BatchQuizMap GetBatchQuizMap(object id)
        {
            return null;// _db.BatchQuizMaps.Find(id);
        }

        public BatchQuizMap AddBatchQuizMap(BatchQuizMap obj)
        {
            //_db.BatchQuizMaps.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public BatchQuizMap EditBatchQuizMap(BatchQuizMap obj)
        {
            //_db.Entry<BatchQuizMap>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public BatchQuizMap DeleteBatchQuizMap(BatchQuizMap obj)
        {
            //_db.BatchQuizMaps.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region BatchUserMap Mathods

        public IQueryable<BatchUserMap> GetAllBatchUserMaps()
        {
            return null;// _db.BatchUserMaps.AsQueryable();
        }

        public BatchUserMap GetBatchUserMap(object id)
        {
            return null;// _db.BatchUserMaps.Find(id);
        }

        public BatchUserMap AddBatchUserMap(BatchUserMap obj)
        {
            //_db.BatchUserMaps.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public BatchUserMap EditBatchUserMap(BatchUserMap obj)
        {
            //_db.Entry<BatchUserMap>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public BatchUserMap DeleteBatchUserMap(BatchUserMap obj)
        {
            //_db.BatchUserMaps.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region Attempt Mathods

        public IQueryable<Attempt> GetAllAttempts()
        {
            return null;// _db.Attempts.AsQueryable();
        }

        public Attempt GetAttempt(object id)
        {
            return null;// _db.Attempts.Find(id);
        }

        public Attempt AddAttempt(Attempt obj)
        {
            //_db.Attempts.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public Attempt EditAttempt(Attempt obj)
        {
            //_db.Entry<Attempt>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public Attempt DeleteAttempt(Attempt obj)
        {
            //_db.Attempts.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region AttemptDetail Mathods

        public IQueryable<AttemptDetail> GetAllAttemptDetails()
        {
            return null;// _db.AttemptDetails.AsQueryable();
        }

        public AttemptDetail GetAttemptDetail(object id)
        {
            return null;// _db.AttemptDetails.Find(id);
        }

        public AttemptDetail AddAttemptDetail(AttemptDetail obj)
        {
            //_db.AttemptDetails.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public AttemptDetail EditAttemptDetail(AttemptDetail obj)
        {
            //_db.Entry<AttemptDetail>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public AttemptDetail DeleteAttemptDetail(AttemptDetail obj)
        {
            //_db.AttemptDetails.Remove(obj);
            //_db.SaveChanges();
            return obj;
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
        #region webpages_OAuthMembership Mathods

        public IQueryable<webpages_OAuthMembership> GetAllwebpages_OAuthMembership()
        {
            return null;// _db.webpages_OAuthMembership.AsQueryable();
        }

        public webpages_OAuthMembership Getwebpages_OAuthMembership(object id)
        {
            return null;// _db.webpages_OAuthMembership.Find(id);
        }

        public webpages_OAuthMembership Addwebpages_OAuthMembership(webpages_OAuthMembership obj)
        {
            //_db.webpages_OAuthMembership.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public webpages_OAuthMembership Editwebpages_OAuthMembership(webpages_OAuthMembership obj)
        {
            //_db.Entry<webpages_OAuthMembership>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public webpages_OAuthMembership Deletewebpages_OAuthMembership(webpages_OAuthMembership obj)
        {
            //_db.webpages_OAuthMembership.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region webpages_Membership Mathods

        public IQueryable<webpages_Membership> GetAllwebpages_Membership()
        {
            return null;// _db.webpages_Membership.AsQueryable();
        }

        public webpages_Membership Getwebpages_Membership(object id)
        {
            return null;// _db.webpages_Membership.Find(id);
        }

        public webpages_Membership Addwebpages_Membership(webpages_Membership obj)
        {
            //_db.webpages_Membership.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public webpages_Membership Editwebpages_Membership(webpages_Membership obj)
        {
            //_db.Entry<webpages_Membership>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public webpages_Membership Deletewebpages_Membership(webpages_Membership obj)
        {
            //_db.webpages_Membership.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region webpages_Roles Mathods

        public IQueryable<webpages_Roles> GetAllwebpages_Roles()
        {
            return null;// _db.webpages_Roles.AsQueryable();
        }

        public webpages_Roles Getwebpages_Roles(object id)
        {
            return null;// _db.webpages_Roles.Find(id);
        }

        public webpages_Roles Addwebpages_Roles(webpages_Roles obj)
        {
            //_db.webpages_Roles.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public webpages_Roles Editwebpages_Roles(webpages_Roles obj)
        {
            //_db.Entry<webpages_Roles>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public webpages_Roles Deletewebpages_Roles(webpages_Roles obj)
        {
            //_db.webpages_Roles.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region webpages_UsersInRoles Mathods

        public IQueryable<webpages_UsersInRoles> GetAllwebpages_UsersInRoles()
        {
            return null;// _db.webpages_UsersInRoles.AsQueryable();
        }

        public webpages_UsersInRoles Getwebpages_UsersInRoles(object id)
        {
            return null;// _db.webpages_UsersInRoles.Find(id);
        }

        public webpages_UsersInRoles Addwebpages_UsersInRoles(webpages_UsersInRoles obj)
        {
            //_db.webpages_UsersInRoles.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public webpages_UsersInRoles Editwebpages_UsersInRoles(webpages_UsersInRoles obj)
        {
            //_db.Entry<webpages_UsersInRoles>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public webpages_UsersInRoles Deletewebpages_UsersInRoles(webpages_UsersInRoles obj)
        {
            //_db.webpages_UsersInRoles.Remove(obj);
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
            obj= _db.AddCompany(obj);
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

        public Batch GetBatch(object id)
        {
            return null;// _db.Batches.Find(id);
        }

        public Batch AddBatch(Batch obj)
        {
            //_db.Batches.Add(obj);
            //_db.SaveChanges();
            return obj;
        }

        public Batch EditBatch(Batch obj)
        {
            //_db.Entry<Batch>(obj).State = System.Data.EntityState.Modified;
            // _db.SaveChanges();
            return obj;
        }

        public Batch DeleteBatch(Batch obj)
        {
            //_db.Batches.Remove(obj);
            //_db.SaveChanges();
            return obj;
        }

        #endregion
        #region Student Mathods

        public List<Student> GetAllStudents()
        {
            return _db.GetAllStudents();
        }

        public List<Student> GetAllStudents(string query)
        {
            return _db.GetAllStudents(query);
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
    }
}
