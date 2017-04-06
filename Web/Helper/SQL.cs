using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public static class SQL
    {
        #region Company

        public const string SelectAllCompany = @"SELECT * FROM COMPANY;";

        public const string SelectAllCompanyLike = @"SELECT * FROM COMPANY WHERE Title LIKE @Term OR Code LIKE @Term OR 
                                                        Address LIKE @Term OR Contact LIKE @Term;";

        public const string SelectCompanyByID = @"SELECT * FROM COMPANY WHERE ID=@ID;";

        public const string UpdateCompany = @"UPDATE Company
                                               SET Title = @Title
                                                  ,Code = @Code
                                                  ,Address = @Address
                                                  ,Contact = @Contact
                                                  ,OtherDetails = @OtherDetails
                                                  ,CreationDate = @CreationDate
                                                  ,CreationTime = @CreationTime
                                                  ,ModificationDate = @ModificationDate
                                                  ,CreatedBy = @CreatedBy
                                                  ,ModifiedBy = @ModifiedBy
                                                  ,ModificationTime = @ModificationTime
                                                  ,LicenceFrom = @LicenceFrom
                                                  ,LicenceTo = @LicenceTo
                                                  ,IsActive = @IsActive
                                             WHERE ID = @ID;";

        public const string InsertCompany = @"INSERT INTO Company(ID,Title,Code,Address,Contact,OtherDetails,CreationDate,CreationTime,
                                                ModificationDate,CreatedBy,ModifiedBy,ModificationTime,LicenceFrom,LicenceTo,IsActive)
                                                VALUES(@ID,@Title,@Code,@Address,@Contact,@OtherDetails,@CreationDate,@CreationTime,
                                                @ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@LicenceFrom,@LicenceTo,@IsActive)";

        public const string DeleteCompany = @"DELETE FROM Company WHERE ID=@ID";

        public const string SoftDeleteCompany = @"UPDATE Company SET IsActive=0 WHERE ID=@ID";

        public const string CheckCompanyActiveStatus = @"SELECT * FROM Company WHERE ID = @ID AND LicenceTo>= @LicenceTo AND IsActive =1;";

        #endregion

        #region Student



        public const string SelectAllStudent = @"SELECT * FROM STUDENT;";

        public const string SelectAllStudentLike = @"SELECT * FROM Student WHERE Email LIKE @Term OR FirstName LIKE @Term OR LastName LIKE @Term 
	                                                    OR MiddleName LIKE @Term OR EnrollmentNo LIKE @Term OR Contact LIKE @Term 
	                                                    OR Address LIKE @Term;";

        public const string SelectStudentByID = @"SELECT * FROM STUDENT WHERE ID=@ID;";

        public const string UpdateStudent = @"UPDATE Student
                                               SET CompanyID = @CompanyID
                                                  ,Email = @Email
                                                  ,Password = @Password
                                                  ,FirstName = @FirstName
                                                  ,MiddleName = @MiddleName
                                                  ,LastName = @LastName
                                                  ,EnrollmentNo = @EnrollmentNo
                                                  ,Contact = @Contact
                                                  ,Address = @Address
                                                  ,OtherDetails = @OtherDetails
                                                  ,CreationDate = @CreationDate
                                                  ,CreationTime = @CreationTime
                                                  ,ModificationDate = @ModificationDate
                                                  ,CreatedBy = @CreatedBy
                                                  ,ModifiedBy = @ModifiedBy
                                                  ,ModificationTime = @ModificationTime
                                                  ,IsActive = @IsActive
                                                  ,DateOfBirth = @DateOfBirth
                                             WHERE ID = @ID";

        public const string SoftDeleteStudent = @"UPDATE Student SET IsActive=0 WHERE ID=@ID";

        public const string InsertStudent = @"INSERT INTO Student(ID,CompanyID,Email,Password,FirstName,MiddleName,
                                                LastName,EnrollmentNo,Contact,Address,OtherDetails,CreationDate,CreationTime,
                                                ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive,DateOfBirth)
                                              VALUES(@ID,@CompanyID,@Email,@Password,@FirstName,@MiddleName,
                                                @LastName,@EnrollmentNo,@Contact,@Address,@OtherDetails,@CreationDate,@CreationTime,
                                                @ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive,@DateOfBirth)";

        #endregion

        #region Batch

        public const string SelectAllBatch = @"SELECT * FROM BATCH;";

        public const string SelectAllBatchLike = @"SELECT * FROM BATCH WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectBatchByID = @"SELECT * FROM BATCH WHERE ID=@ID;";

        public const string UpdateBatch = @"UPDATE Batch
                                               SET CompanyID = @CompanyID
                                                  ,Title = @Title
                                                  ,Code = @Code
                                                  ,OtherDetails = @OtherDetails
                                                  ,CreationDate = @CreationDate
                                                  ,CreationTime = @CreationTime
                                                  ,ModificationDate = @ModificationDate
                                                  ,CreatedBy = @CreatedBy
                                                  ,ModifiedBy = @ModifiedBy
                                                  ,ModificationTime = @ModificationTime
                                                  ,StartFrom = @StartFrom
                                                  ,EndTo = @EndTo
                                                  ,IsActive = @IsActive
                                             WHERE ID = @ID;";

        public const string SoftDeleteBatch = @"UPDATE BATCH SET IsActive=0 WHERE ID=@ID";

        public const string InsertBatch = @"INSERT INTO Batch
                                               (ID,CompanyID,Title,Code,OtherDetails,CreationDate,CreationTime,ModificationDate
                                               ,CreatedBy,ModifiedBy,ModificationTime,StartFrom,EndTo,IsActive)
                                                VALUES (@ID,@CompanyID,@Title,@Code,@OtherDetails,@CreationDate,@CreationTime,@ModificationDate
                                               ,@CreatedBy,@ModifiedBy,@ModificationTime,@StartFrom,@EndTo,@IsActive);";

        #endregion


        #region Quiz

        public const string SelectAllQuiz = @"SELECT * FROM QUIZ;";

        public const string SelectAllQuizLike = @"SELECT * FROM QUIZ WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectQuizByID = @"SELECT * FROM QUIZ WHERE ID=@ID;";

        public const string UpdateQuiz = @"UPDATE Quiz
                                               SET CompanyID = @CompanyID
                                                  ,Title = @Title
                                                  ,Code = @Code
                                                  ,Desciption = @Desciption
                                                  ,QuestionDbFile = @QuestionDbFile
                                                  ,OtherDetails = @OtherDetails
                                                  ,CreationDate = @CreationDate
                                                  ,CreationTime = @CreationTime
                                                  ,ModificationDate = @ModificationDate
                                                  ,CreatedBy = @CreatedBy
                                                  ,ModifiedBy = @ModifiedBy
                                                  ,ModificationTime = @ModificationTime
                                                  ,IsActive = @IsActive
                                                  ,AvailableFromDate = @AvailableFromDate
                                                  ,AvailableToDate = @AvailableToDate
                                                  ,AvailableFromTime = @AvailableFromTime
                                                  ,AvailableToTime = @AvailableToTime
                                             WHERE ID = @ID;";

        public const string SoftDeleteQuiz = @"UPDATE QUIZ SET IsActive=0 WHERE ID=@ID";

        public const string InsertQuiz = @"INSERT INTO Quiz(ID,CompanyID,Title,Code,Desciption,QuestionDbFile,OtherDetails,CreationDate,CreationTime
                                           ,ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive
                                           ,AvailableFromDate,AvailableToDate,AvailableFromTime,AvailableToTime)
                                            VALUES(@ID,@CompanyID,@Title,@Code,@Desciption,@QuestionDbFile,@OtherDetails
                                           ,@CreationDate,@CreationTime,@ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive
                                           ,@AvailableFromDate,@AvailableToDate,@AvailableFromTime,@AvailableToTime);";

        #endregion

        public const string UserLoginCheck = @"SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,'*' AS AccessLevel 
                                                FROM Student WHERE Email = @Email AND Password = @Password AND IsActive=1;";

        public const string ChangeUserPassword = @"UPDATE Student set Password=@NewPassword WHERE Email=@Email AND Password=@Password;
                                                   SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,'*' AS AccessLevel 
                                                        FROM Student WHERE Email = @Email AND Password = @NewPassword;";
    }
}