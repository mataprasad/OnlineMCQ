using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Web.Data.SQLite;
using Web.Models;

namespace Web.Data
{
    public interface IDbAccess : IDisposable
    {
        List<McqQuestion> GetAllQuestions(string dbFilePath);
        bool BulkInsertQuestions(DataTable dt, string dbFilePath, string loggedUserId, string quizId);
        bool BulkInsertStudents(DataTable dt, string companyId, string loggedUserId, string dbFilePath);
        List<T> GetQueryData<T>(string sql);
        List<T> GetQueryData<T>(string sql, object param);
        List<T> GetQueryData<T>(CommandDefinition cmdDef);
        int Execute(string sql, object param);
    }
}