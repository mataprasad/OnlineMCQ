using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SQLite;
using System.Data;

namespace Web.Data.SQLite
{
    public class SQLiteHelper
    {
        private SQLiteConnection _con = null;

        public SQLiteHelper(string dbFilePath)
        {
            _con = new SQLiteConnection(string.Format(@"Data Source={0};Version=3;UseUTF16Encoding=True;", dbFilePath));
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
    }
}