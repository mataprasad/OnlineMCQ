using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using Web.Models;
using System.Data.Common;
using Web.Helper;

namespace Web.Data.SQLite
{
    public class SQLiteHelper : IDbAccess, IDisposable
    {
        private SQLiteConnection _con = null;

        public SQLiteHelper(string dbFilePath)
        {
            _con = new SQLiteConnection(string.Format(@"Data Source={0};Version=3;UseUTF16Encoding=True;", dbFilePath));
        }

        public void Trace()
        {
            if (_con.State == ConnectionState.Closed)
            {
                _con.Open();
                _con.Trace += new SQLiteTraceEventHandler((o, e) =>
                {
                    var sql = (e as System.Data.SQLite.TraceEventArgs).Statement;
                });
            }
        }

        public List<McqQuestion> GetAllQuestions()
        {
            return _con.Query<McqQuestion>("SELECT * FROM DT_QUESTIONS;").ToList();
        }

        public bool BulkInsertQuestions(DataTable dt)
        {
            try
            {
                _con.Open();
                SQLiteCommand cmd = null;
                foreach (DataRow item in dt.Rows)
                {

                    var sql = @"INSERT INTO DT_QUESTIONS (
                            QUIZ_ID ,
                            QUESTION_ID ,
                            SECTION_NAME ,
                            QUESTION_TEXT_EN ,
                            QUESTION_TEXT_HI ,
                            OPTION_A_EN ,
                            OPTION_B_EN	,
                            OPTION_C_EN	,
                            OPTION_D_EN	,
                            OPTION_E_EN	,
                            OPTION_A_HI	,
                            OPTION_B_HI	,
                            OPTION_C_HI	,
                            OPTION_D_HI	,
                            OPTION_E_HI	,
                            OPTION_A_ID ,
                            OPTION_B_ID	,
                            OPTION_C_ID	,
                            OPTION_D_ID	,
                            OPTION_E_ID	,
                            CORRECT_OPTIONS)
                            VALUES (
                            @QUIZ_ID,
                            @QUESTION_ID,
                            @SECTION_NAME ,
                            @QUESTION_TEXT_EN,
                            @QUESTION_TEXT_HI,
                            @OPTION_A_EN,
                            @OPTION_B_EN,
                            @OPTION_C_EN,
                            @OPTION_D_EN,
                            @OPTION_E_EN,
                            @OPTION_A_HI,
                            @OPTION_B_HI,
                            @OPTION_C_HI,
                            @OPTION_D_HI,
                            @OPTION_E_HI,
                            @OPTION_A_ID,
                            @OPTION_B_ID,
                            @OPTION_C_ID,
                            @OPTION_D_ID,
                            @OPTION_E_ID,
                            @CORRECT_OPTIONS)";
                    cmd = new SQLiteCommand();
                    cmd.Connection = _con;
                    cmd.CommandText = sql;
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@QUIZ_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@QUESTION_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@SECTION_NAME", Convert.ToString(item["SECTION_NAME"]));
                    cmd.Parameters.AddWithValue("@QUESTION_TEXT_EN", Convert.ToString(item["QUESTION_TEXT_EN"]));
                    cmd.Parameters.AddWithValue("@QUESTION_TEXT_HI", Convert.ToString(item["QUESTION_TEXT_HI"]));

                    cmd.Parameters.AddWithValue("@OPTION_A_EN", Convert.ToString(item["OPTION_A_EN"]));
                    cmd.Parameters.AddWithValue("@OPTION_B_EN", Convert.ToString(item["OPTION_B_EN"]));
                    cmd.Parameters.AddWithValue("@OPTION_C_EN", Convert.ToString(item["OPTION_C_EN"]));
                    cmd.Parameters.AddWithValue("@OPTION_D_EN", Convert.ToString(item["OPTION_D_EN"]));
                    cmd.Parameters.AddWithValue("@OPTION_E_EN", Convert.ToString(item["OPTION_E_EN"]));

                    cmd.Parameters.AddWithValue("@OPTION_A_HI", Convert.ToString(item["OPTION_A_HI"]));
                    cmd.Parameters.AddWithValue("@OPTION_B_HI", Convert.ToString(item["OPTION_B_HI"]));
                    cmd.Parameters.AddWithValue("@OPTION_C_HI", Convert.ToString(item["OPTION_C_HI"]));
                    cmd.Parameters.AddWithValue("@OPTION_D_HI", Convert.ToString(item["OPTION_D_HI"]));
                    cmd.Parameters.AddWithValue("@OPTION_E_HI", Convert.ToString(item["OPTION_E_HI"]));

                    cmd.Parameters.AddWithValue("@OPTION_A_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@OPTION_B_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@OPTION_C_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@OPTION_D_ID", Convert.ToString(Guid.NewGuid()));
                    cmd.Parameters.AddWithValue("@OPTION_E_ID", Convert.ToString(Guid.NewGuid()));

                    cmd.Parameters.AddWithValue("@CORRECT_OPTIONS", Convert.ToString(item["CORRECT_OPTION"]));

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_con.State == ConnectionState.Open)
                {
                    _con.Close();
                }
            }
            return true;
        }

        public List<T> GetQueryData<T>(string sql)
        {
            return _con.Query<T>(sql).ToList();
        }

        public List<T> GetQueryData<T>(string sql, object param)
        {
            return _con.Query<T>(sql, param).ToList();
        }

        public List<T> GetQueryData<T>(CommandDefinition cmdDef)
        {
            return _con.Query<T>(cmdDef).ToList();
        }

        public int Execute(string sql, object param)
        {
            return _con.Execute(sql, param);
        }

        public void Dispose()
        {
            if (_con != null)
            {
                _con.Dispose();
            }
        }

        public bool BulkInsertStudents(DataTable dt, string companyId, string loggedUserId, string dbFilePath)
        {
            try
            {
                using (var localConnection = new SQLiteConnection(string.Format(@"Data Source={0};Version=3;UseUTF16Encoding=True;", dbFilePath)))
                {
                    localConnection.Open();

                    SQLiteCommand cmd = null;

                    var currentDateInt = Utility.GetCurrentDateInt();
                    var currentTimeInt = Utility.GetCurrentTimeInt();

                    foreach (DataRow item in dt.Rows)
                    {
                        cmd = new SQLiteCommand();
                        cmd.Connection = localConnection;
                        cmd.CommandText = SQL.InsertStudent;
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@ID", Convert.ToString(Guid.NewGuid()).ToLower());
                        cmd.Parameters.AddWithValue("@CompanyID", companyId);

                        cmd.Parameters.AddWithValue("@CreatedBy", loggedUserId);
                        cmd.Parameters.AddWithValue("@CreationDate", currentDateInt);
                        cmd.Parameters.AddWithValue("@CreationTime", currentTimeInt);
                        cmd.Parameters.AddWithValue("@ModifiedBy", loggedUserId);
                        cmd.Parameters.AddWithValue("@ModificationDate", currentDateInt);
                        cmd.Parameters.AddWithValue("@ModificationTime", currentTimeInt);
                        cmd.Parameters.AddWithValue("@IsActive", true);

                        cmd.Parameters.AddWithValue("@Email", Convert.ToString(item["Email"]));
                        cmd.Parameters.AddWithValue("@Password", Convert.ToString(item["DateOfBirth"]));
                        cmd.Parameters.AddWithValue("@FirstName", Convert.ToString(item["FirstName"]));
                        cmd.Parameters.AddWithValue("@MiddleName", Convert.ToString(item["MiddleName"]));
                        cmd.Parameters.AddWithValue("@LastName", Convert.ToString(item["LastName"]));
                        cmd.Parameters.AddWithValue("@DateOfBirth", Convert.ToInt32(item["DateOfBirth"]));
                        cmd.Parameters.AddWithValue("@EnrollmentNo", Convert.ToString(item["EnrollmentNo"]));
                        cmd.Parameters.AddWithValue("@Contact", Convert.ToString(item["Contact"]));
                        cmd.Parameters.AddWithValue("@Address", Convert.ToString(item["Address"]));
                        cmd.Parameters.AddWithValue("@OtherDetails", Convert.ToString(item["OtherDetails"]));

                        cmd.ExecuteNonQuery();
                    }

                    cmd = null;
                }
            }
            catch
            {
                throw;
            }
            return true;
        }
    }
}