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

        public const string SelectAllStudentADMIN = @"SELECT * FROM STUDENT;";
        public const string SelectAllStudentLikeADMIN = @"SELECT * FROM Student WHERE Email LIKE @Term OR FirstName LIKE @Term OR LastName LIKE @Term 
	                                                    OR MiddleName LIKE @Term OR EnrollmentNo LIKE @Term OR Contact LIKE @Term 
	                                                    OR Address LIKE @Term;";

        public const string SelectAllStudent = @"SELECT * FROM STUDENT WHERE ID<>'38f65c64-37b0-4a6a-b945-1f879a1e1c13';";

        public const string SelectAllStudentLike = @"SELECT * FROM Student WHERE (Email LIKE @Term OR FirstName LIKE @Term OR LastName LIKE @Term 
	                                                    OR MiddleName LIKE @Term OR EnrollmentNo LIKE @Term OR Contact LIKE @Term 
	                                                    OR Address LIKE @Term) AND ID<>'38f65c64-37b0-4a6a-b945-1f879a1e1c13';";

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
                                                  ,Roles = @Roles
                                             WHERE ID = @ID";

        public const string SoftDeleteStudent = @"UPDATE Student SET IsActive=0 WHERE ID=@ID";

        public const string InsertStudent = @"INSERT INTO Student(ID,CompanyID,Email,Password,FirstName,MiddleName,
                                                LastName,EnrollmentNo,Contact,Address,OtherDetails,CreationDate,CreationTime,
                                                ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive,DateOfBirth,Roles)
                                              VALUES(@ID,@CompanyID,@Email,@Password,@FirstName,@MiddleName,
                                                @LastName,@EnrollmentNo,@Contact,@Address,@OtherDetails,@CreationDate,@CreationTime,
                                                @ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive,@DateOfBirth,@Roles)";

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

        #region BatchQuizMap

        public const string SelectAllBatchQuizMap = @"SELECT * FROM BATCHQUIZMAP;";

        public const string SelectAllBatchQuizMapLike = @"SELECT * FROM BATCHQUIZMAP WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectBatchQuizMapByID = @"SELECT * FROM BATCHQUIZMAP WHERE ID=@ID;";

        public const string UpdateBatchQuizMap = @"UPDATE BatchQuizMap
                                                       SET CompanyID = @CompanyID
                                                          ,BatchID = @BatchID
                                                          ,QuizID = @QuizID
                                                          ,OtherDetails = @OtherDetails
                                                          ,CreationDate = @CreationDate
                                                          ,CreationTime = @CreationTime
                                                          ,ModificationDate = @ModificationDate
                                                          ,CreatedBy = @CreatedBy
                                                          ,ModifiedBy = @ModifiedBy
                                                          ,ModificationTime = @ModificationTime
                                                          ,IsActive = @IsActive
                                                     WHERE ID = @ID;";

        public const string SoftDeleteBatchQuizMap = @"UPDATE BATCHQUIZMAP SET IsActive=0 WHERE ID=@ID";

        public const string InsertBatchQuizMap = @"INSERT INTO BatchQuizMap
                                                   (ID,CompanyID,BatchID,QuizID,OtherDetails,CreationDate,CreationTime,ModificationDate
                                                   ,CreatedBy,ModifiedBy,ModificationTime,IsActive)
                                             VALUES
                                                   (@ID,@CompanyID,@BatchID,@QuizID,@OtherDetails,@CreationDate,@CreationTime,@ModificationDate
                                                   ,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive);";

        #endregion

        #region BatchUserMap

        public const string SelectAllBatchUserMap = @"SELECT * FROM BATCHUSERMAP;";

        public const string SelectAllBatchUserMapLike = @"SELECT * FROM BATCHUSERMAP WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectBatchUserMapByID = @"SELECT * FROM BATCHUSERMAP WHERE ID=@ID;";

        public const string UpdateBatchUserMap = @"UPDATE BatchUserMap
                               SET CompanyID = @CompanyID
                                  ,BatchID = @BatchID
                                  ,UserID = @UserID
                                  ,OtherDetails = @OtherDetails
                                  ,CreationDate = @CreationDate
                                  ,CreationTime = @CreationTime
                                  ,ModificationDate = @ModificationDate
                                  ,CreatedBy = @CreatedBy
                                  ,ModifiedBy = @ModifiedBy
                                  ,ModificationTime = @ModificationTime
                                  ,IsActive = @IsActive
                             WHERE ID = @ID;";

        public const string SoftDeleteBatchUserMap = @"UPDATE BATCHUSERMAP SET IsActive=0 WHERE ID=@ID";

        public const string InsertBatchUserMap = @"INSERT INTO BatchUserMap
                                                   (ID,CompanyID,BatchID,UserID,OtherDetails,CreationDate,CreationTime
                                                   ,ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive)
                                                    VALUES
                                                   (@ID,@CompanyID,@BatchID,@UserID,@OtherDetails,@CreationDate,@CreationTime,
                                                   @ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive)";

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
                                                  ,TimeLimit = @TimeLimit
                                                  ,CorrectAnswerMarks = @CorrectAnswerMarks
                                                  ,NegativeMarking = @NegativeMarking
                                                  ,PassingPercentage = @PassingPercentage
                                                  ,ShuffleQuestions = @ShuffleQuestions
                                                  ,ShuffleOptions = @ShuffleOptions
                                                  ,ShowReportAfterTest = @ShowReportAfterTest
                                                  ,RevealCorrectOptionAfterTest = @RevealCorrectOptionAfterTest
                                                  ,AllowMultipleAttempts = @AllowMultipleAttempts 
                                                  ,PreventWindowAndTabChange = @PreventWindowAndTabChange
                                                  ,HindiEnabled = @HindiEnabled
                                                  ,IsOnlyInClass = @IsOnlyInClass
                                                  ,Otp = @Otp
                                                  ,IsPublished = @IsPublished
                                             WHERE ID = @ID;";

        public const string SoftDeleteQuiz = @"UPDATE QUIZ SET IsActive=0 WHERE ID=@ID";

        public const string InsertQuiz = @"INSERT INTO Quiz(ID,CompanyID,Title,Code,Desciption,QuestionDbFile,OtherDetails,CreationDate,CreationTime
                                           ,ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive
                                           ,AvailableFromDate,AvailableToDate,AvailableFromTime,AvailableToTime
                                           ,TimeLimit,CorrectAnswerMarks,NegativeMarking,PassingPercentage,ShuffleQuestions,ShuffleOptions
                                           ,ShowReportAfterTest,RevealCorrectOptionAfterTest,AllowMultipleAttempts,PreventWindowAndTabChange,HindiEnabled
                                           ,IsOnlyInClass,Otp,IsPublished)
                                            VALUES(@ID,@CompanyID,@Title,@Code,@Desciption,@QuestionDbFile,@OtherDetails
                                           ,@CreationDate,@CreationTime,@ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive
                                           ,@AvailableFromDate,@AvailableToDate,@AvailableFromTime,@AvailableToTime
                                           ,@TimeLimit,@CorrectAnswerMarks,@NegativeMarking,@PassingPercentage,@ShuffleQuestions
                                           ,@ShuffleOptions,@ShowReportAfterTest,@RevealCorrectOptionAfterTest,@AllowMultipleAttempts,@PreventWindowAndTabChange,@HindiEnabled
                                           ,@IsOnlyInClass,@Otp,@IsPublished);";

        #endregion

        #region Attempt

        public const string SelectAllAttempt = @"SELECT * FROM ATTEMPT;";

        public const string SelectAllAttemptLike = @"SELECT * FROM ATTEMPT WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectAttemptByID = @"SELECT * FROM ATTEMPT WHERE ID=@ID;";

        public const string UpdateAttempt = @"UPDATE Attempt
                                               SET CompanyID = @CompanyID
                                                  ,BatchID = @BatchID
                                                  ,UserID = @UserID
                                                  ,QuizID = @QuizID
                                                  ,OtherDetails = @OtherDetails
                                                  ,CreationDate = @CreationDate
                                                  ,CreationTime = @CreationTime
                                                  ,ModificationDate = @ModificationDate
                                                  ,CreatedBy = @CreatedBy
                                                  ,ModifiedBy = @ModifiedBy
                                                  ,ModificationTime = @ModificationTime
                                                  ,IsActive = @IsActive
                                             WHERE ID = @ID;";

        public const string SoftDeleteAttempt = @"UPDATE ATTEMPT SET IsActive=0 WHERE ID=@ID";

        public const string InsertAttempt = @"INSERT INTO Attempt
                                               (ID,CompanyID,BatchID,UserID,QuizID,OtherDetails,CreationDate
                                               ,CreationTime,ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive)
                                                VALUES
                                               (@ID,@CompanyID,@BatchID,@UserID,@QuizID,@OtherDetails,@CreationDate
                                               ,@CreationTime,@ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive)";

        #endregion

        #region AttemptDetail

        public const string SelectAllAttemptDetail = @"SELECT * FROM ATTEMPTDETAIL;";

        public const string SelectAllAttemptDetailLike = @"SELECT * FROM ATTEMPTDETAIL WHERE Title LIKE @Term OR Code LIKE @Term OR OtherDetails LIKE @Term;";

        public const string SelectAttemptDetailByID = @"SELECT * FROM ATTEMPTDETAIL WHERE ID=@ID;";

        public const string UpdateAttemptDetail = @"UPDATE AttemptDetail
                                                       SET AttemptID = @AttemptID
                                                          ,ResponseKey = @ResponseKey
                                                          ,ResponseValue = @ResponseValue
                                                          ,CreationDate = @CreationDate
                                                          ,CreationTime = @CreationTime
                                                          ,ModificationDate = @ModificationDate
                                                          ,CreatedBy = @CreatedBy
                                                          ,ModifiedBy = @ModifiedBy
                                                          ,ModificationTime = @ModificationTime
                                                          ,IsActive = @IsActive
                                                     WHERE ID = @ID;";

        public const string SoftDeleteAttemptDetail = @"UPDATE ATTEMPTDETAIL SET IsActive=0 WHERE ID=@ID";

        public const string InsertAttemptDetail = @"INSERT INTO AttemptDetail
                                                       (ID,AttemptID,ResponseKey,ResponseValue,CreationDate,CreationTime
                                                       ,ModificationDate,CreatedBy,ModifiedBy,ModificationTime,IsActive)
                                                 VALUES
                                                       (@ID,@AttemptID,@ResponseKey,@ResponseValue,@CreationDate,@CreationTime
                                                       ,@ModificationDate,@CreatedBy,@ModifiedBy,@ModificationTime,@IsActive);";

        #endregion

        #region Question

        public const string SelectAllQuestion = @"SELECT * FROM DT_QUESTIONS;";

        public const string SelectAllQuestionLike = @"SELECT * FROM DT_QUESTIONS WHERE QUESTION_TEXT_EN LIKE @Term OR SECTION_NAME LIKE @Term;";

        public const string SelectQuestionByID = @"SELECT * FROM DT_QUESTIONS WHERE QUESTION_ID=@ID;";

        public const string UpdateQuestion = @"UPDATE DT_QUESTIONS
                                                   SET QUIZ_ID = @QUIZ_ID
                                                      ,SECTION_NAME = @SECTION_NAME
                                                      ,QUESTION_TEXT_EN = @QUESTION_TEXT_EN
                                                      ,QUESTION_TEXT_HI = @QUESTION_TEXT_HI
                                                      ,OPTION_A_EN = @OPTION_A_EN
                                                      ,OPTION_B_EN = @OPTION_B_EN
                                                      ,OPTION_C_EN = @OPTION_C_EN
                                                      ,OPTION_D_EN = @OPTION_D_EN
                                                      ,OPTION_E_EN = @OPTION_E_EN
                                                      ,OPTION_A_HI = @OPTION_A_HI
                                                      ,OPTION_B_HI = @OPTION_B_HI
                                                      ,OPTION_C_HI = @OPTION_C_HI
                                                      ,OPTION_D_HI = @OPTION_D_HI
                                                      ,OPTION_E_HI = @OPTION_E_HI
                                                      ,OPTION_A_ID = @OPTION_A_ID
                                                      ,OPTION_B_ID = @OPTION_B_ID
                                                      ,OPTION_C_ID = @OPTION_C_ID
                                                      ,OPTION_D_ID = @OPTION_D_ID
                                                      ,OPTION_E_ID = @OPTION_E_ID
                                                      ,CORRECT_OPTIONS = @CORRECT_OPTIONS
                                                      ,IS_ACTIVE = @IS_ACTIVE
                                                      ,CREATED_BY = @CREATED_BY
                                                      ,CREATED_ON = @CREATED_ON
                                                 WHERE QUESTION_ID = @QUESTION_ID";

        public const string SoftDeleteQuestion = @"DELETE FROM DT_QUESTIONS WHERE QUESTION_ID=@ID";

        public const string InsertQuestion = @"INSERT INTO DT_QUESTIONS
                                                   (QUIZ_ID,QUESTION_ID,SECTION_NAME,QUESTION_TEXT_EN,QUESTION_TEXT_HI
                                                   ,OPTION_A_EN,OPTION_B_EN,OPTION_C_EN,OPTION_D_EN,OPTION_E_EN
                                                   ,OPTION_A_HI,OPTION_B_HI,OPTION_C_HI,OPTION_D_HI,OPTION_E_HI
                                                   ,OPTION_A_ID,OPTION_B_ID,OPTION_C_ID,OPTION_D_ID,OPTION_E_ID
                                                   ,CORRECT_OPTIONS,IS_ACTIVE,CREATED_BY,CREATED_ON)
                                             VALUES
                                                   (@QUIZ_ID,@QUESTION_ID,@SECTION_NAME,@QUESTION_TEXT_EN,@QUESTION_TEXT_HI
                                                   ,@OPTION_A_EN,@OPTION_B_EN,@OPTION_C_EN,@OPTION_D_EN,@OPTION_E_EN
                                                   ,@OPTION_A_HI,@OPTION_B_HI,@OPTION_C_HI,@OPTION_D_HI,@OPTION_E_HI
                                                   ,@OPTION_A_ID,@OPTION_B_ID,@OPTION_C_ID,@OPTION_D_ID,@OPTION_E_ID
                                                   ,@CORRECT_OPTIONS,@IS_ACTIVE,@CREATED_BY,@CREATED_ON)";

        #endregion

        #region LoginInfo

        public const string UserLoginCheck = @"SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,Roles AS AccessLevel 
                                                FROM Student WHERE Email = @Email AND Password = @Password AND IsActive=1;";

        public const string ChangeUserPassword = @"UPDATE Student set Password=@NewPassword WHERE Email=@Email AND Password=@Password;
                                                   SELECT ID,CompanyID,Email AS UserName,Email AS ScreenName,Roles AS AccessLevel 
                                                        FROM Student WHERE Email = @Email AND Password = @NewPassword;";

        #endregion
    }
}