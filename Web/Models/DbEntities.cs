using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public partial class  Quiz
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Desciption { get; set; }
        public string QuestionDbFile { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class  BatchQuizMap
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

    public partial class  BatchUserMap
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

    public partial class  Attempt
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

    public partial class  AttemptDetail
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

    public partial class  webpages_OAuthMembership
    {
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int? UserId { get; set; }
    }

    public partial class  webpages_Membership
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

    public partial class  webpages_Roles
    {
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }

    public partial class  webpages_UsersInRoles
    {
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }

    public partial class  Company
    {
        public string ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public long? LicenceFrom { get; set; }
        public long? LicenceTo { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class  Batch
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public long? StartFrom { get; set; }
        public long? EndTo { get; set; }
        public bool? IsActive { get; set; }
    }

    public partial class  Student
    {
        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string EnrollmentNo { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string OtherDetails { get; set; }
        public long? CreationDate { get; set; }
        public long? CreationTime { get; set; }
        public long? ModificationDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public long? ModificationTime { get; set; }
        public bool? IsActive { get; set; }
    }


}