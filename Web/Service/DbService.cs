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

        public List<Student> GetAllStudents()
        {
            var data = new List<Student>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Student>(SQL.SelectAllStudent).ToList();
            }
            return data;
        }

        public List<Student> GetAllStudents(string query)
        {
            var data = new List<Student>();
            using (var db = ObjectFactory.CreateDbContext(commonService.GetCompanyDbFilePath(this.company)))
            {
                data = db.GetQueryData<Student>(SQL.SelectAllStudentLike, new { Term = "%" + query + "%" }).ToList();
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

        public List<Batch> GetAllBatches()
        {
            return new List<Batch>();
        }

        public List<Quiz> GetAllQuizs()
        {
            return new List<Quiz>();
        }
    }
}