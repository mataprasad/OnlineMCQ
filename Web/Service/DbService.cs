using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Models;

namespace Web.Service
{
    public class DbService
    {
        public List<Company> GetAllCompanies()
        {
            return new List<Company>();
        }

        public List<Student> GetAllStudents()
        {
            return new List<Student>();
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