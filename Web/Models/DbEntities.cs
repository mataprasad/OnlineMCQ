using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            AvailableFromTime = 0;
            AvailableToTime = 2359999;
        }
        public string ID { get; set; }
        public string CompanyID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Desciption { get; set; }
        public string QuestionDbFile { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Required]
        public long? AvailableFromDate { get; set; }
        [Required]
        public long? AvailableToDate { get; set; }
        [Required]
        public long? AvailableFromTime { get; set; }
        [Required]
        public long? AvailableToTime { get; set; }
    }

    public partial class BatchQuizMap
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string BatchID { get; set; }
        public string QuizID { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class BatchUserMap
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string BatchID { get; set; }
        public string UserID { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class Attempt
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string BatchID { get; set; }
        public string UserID { get; set; }
        public string QuizID { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class AttemptDetail
    {
        public string ID { get; set; }
        public string AttemptID { get; set; }
        public string ResponseKey { get; set; }
        public string ResponseValue { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class webpages_OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int? UserId { get; set; }
    }

    public partial class webpages_Membership
    {
        public int? UserId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string ConfirmationToken { get; set; }
        public bool? IsConfirmed { get; set; }
        public DateTime? LastPasswordFailureDate { get; set; }
        public int? PasswordFailuresSinceLastSuccess { get; set; }
        public string Password { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpirationDate { get; set; }
    }

    public partial class webpages_Roles
    {
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public partial class webpages_UsersInRoles
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }

    public partial class Company
    {
        public string ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Contact { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        [Required]
        public long? LicenceFrom { get; set; }
        [Required]
        public long? LicenceTo { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }

    public partial class Batch
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Code { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        [Required]
        public long? StartFrom { get; set; }
        [Required]
        public long? EndTo { get; set; }
        [Required]
        public bool? IsActive { get; set; }
    }

    public partial class Student
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string EnrollmentNo { get; set; }
        [Required]
        public string Contact { get; set; }
        public string Address { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        [Required]
        public long? DateOfBirth { get; set; }
    }

    public static class DbEntityExt
    {
        public static List<Quiz> ToListOfQuiz(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<Quiz>();
                var obj = new Quiz();
                while (reader.Read())
                {
                    obj = new Quiz();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null;
                    obj.Code = reader["Code"] != DBNull.Value ? (string)reader["Code"] : null;
                    obj.Desciption = reader["Desciption"] != DBNull.Value ? (string)reader["Desciption"] : null;
                    obj.QuestionDbFile = reader["QuestionDbFile"] != DBNull.Value ? (string)reader["QuestionDbFile"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<BatchQuizMap> ToListOfBatchQuizMap(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<BatchQuizMap>();
                var obj = new BatchQuizMap();
                while (reader.Read())
                {
                    obj = new BatchQuizMap();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.BatchID = reader["BatchID"] != DBNull.Value ? (string)reader["BatchID"] : null;
                    obj.QuizID = reader["QuizID"] != DBNull.Value ? (string)reader["QuizID"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<BatchUserMap> ToListOfBatchUserMap(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<BatchUserMap>();
                var obj = new BatchUserMap();
                while (reader.Read())
                {
                    obj = new BatchUserMap();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.BatchID = reader["BatchID"] != DBNull.Value ? (string)reader["BatchID"] : null;
                    obj.UserID = reader["UserID"] != DBNull.Value ? (string)reader["UserID"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<Attempt> ToListOfAttempt(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<Attempt>();
                var obj = new Attempt();
                while (reader.Read())
                {
                    obj = new Attempt();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.BatchID = reader["BatchID"] != DBNull.Value ? (string)reader["BatchID"] : null;
                    obj.UserID = reader["UserID"] != DBNull.Value ? (string)reader["UserID"] : null;
                    obj.QuizID = reader["QuizID"] != DBNull.Value ? (string)reader["QuizID"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<AttemptDetail> ToListOfAttemptDetail(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<AttemptDetail>();
                var obj = new AttemptDetail();
                while (reader.Read())
                {
                    obj = new AttemptDetail();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.AttemptID = reader["AttemptID"] != DBNull.Value ? (string)reader["AttemptID"] : null;
                    obj.ResponseKey = reader["ResponseKey"] != DBNull.Value ? (string)reader["ResponseKey"] : null;
                    obj.ResponseValue = reader["ResponseValue"] != DBNull.Value ? (string)reader["ResponseValue"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<Company> ToListOfCompany(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<Company>();
                var obj = new Company();
                while (reader.Read())
                {
                    obj = new Company();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null;
                    obj.Code = reader["Code"] != DBNull.Value ? (string)reader["Code"] : null;
                    obj.Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : null;
                    obj.Contact = reader["Contact"] != DBNull.Value ? (string)reader["Contact"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.LicenceFrom = reader["LicenceFrom"] != DBNull.Value ? (long?)reader["LicenceFrom"] : null;
                    obj.LicenceTo = reader["LicenceTo"] != DBNull.Value ? (long?)reader["LicenceTo"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<Batch> ToListOfBatch(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<Batch>();
                var obj = new Batch();
                while (reader.Read())
                {
                    obj = new Batch();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.Title = reader["Title"] != DBNull.Value ? (string)reader["Title"] : null;
                    obj.Code = reader["Code"] != DBNull.Value ? (string)reader["Code"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.StartFrom = reader["StartFrom"] != DBNull.Value ? (long?)reader["StartFrom"] : null;
                    obj.EndTo = reader["EndTo"] != DBNull.Value ? (long?)reader["EndTo"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
        public static List<Student> ToListOfStudent(this System.Data.IDataReader reader)
        {
            using (reader)
            {
                var result = new List<Student>();
                var obj = new Student();
                while (reader.Read())
                {
                    obj = new Student();
                    obj.ID = reader["ID"] != DBNull.Value ? (string)reader["ID"] : default(string);
                    obj.CompanyID = reader["CompanyID"] != DBNull.Value ? (string)reader["CompanyID"] : null;
                    obj.Email = reader["Email"] != DBNull.Value ? (string)reader["Email"] : null;
                    obj.Password = reader["Password"] != DBNull.Value ? (string)reader["Password"] : null;
                    obj.FirstName = reader["FirstName"] != DBNull.Value ? (string)reader["FirstName"] : null;
                    obj.MiddleName = reader["MiddleName"] != DBNull.Value ? (string)reader["MiddleName"] : null;
                    obj.LastName = reader["LastName"] != DBNull.Value ? (string)reader["LastName"] : null;
                    obj.EnrollmentNo = reader["EnrollmentNo"] != DBNull.Value ? (string)reader["EnrollmentNo"] : null;
                    obj.Contact = reader["Contact"] != DBNull.Value ? (string)reader["Contact"] : null;
                    obj.Address = reader["Address"] != DBNull.Value ? (string)reader["Address"] : null;
                    obj.OtherDetails = reader["OtherDetails"] != DBNull.Value ? (string)reader["OtherDetails"] : null;
                    obj.CreationDate = reader["CreationDate"] != DBNull.Value ? (long?)reader["CreationDate"] : null;
                    obj.CreationTime = reader["CreationTime"] != DBNull.Value ? (long?)reader["CreationTime"] : null;
                    obj.ModificationDate = reader["ModificationDate"] != DBNull.Value ? (long?)reader["ModificationDate"] : null;
                    obj.CreatedBy = reader["CreatedBy"] != DBNull.Value ? (string)reader["CreatedBy"] : null;
                    obj.ModifiedBy = reader["ModifiedBy"] != DBNull.Value ? (string)reader["ModifiedBy"] : null;
                    obj.ModificationTime = reader["ModificationTime"] != DBNull.Value ? (long?)reader["ModificationTime"] : null;
                    obj.IsActive = reader["IsActive"] != DBNull.Value ? (bool?)reader["IsActive"] : null;

                    result.Add(obj);
                }
                return result;
            }
        }
    }
}