using DocumentFormat.OpenXml.Packaging;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Spreadsheet;
using Web.Models;
using Web.Data.SQLite;

namespace Web.Service
{
    public class CommonService
    {
        private static CommonService _instance = null;
        private static List<string> _roles = null;
        private SQLiteHelper _systemDb = null;

        private CommonService()
        {
            _systemDb = new SQLiteHelper(GetSystemDbFilePath());
        }

        public static CommonService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonService();
                }

                return _instance;
            }
        }

        #region OpenXML to get data table from excel spred sheat

        public DataTable GetDataTableFromExcelSheat(string excelFilePath)
        {
            DataTable dt = new DataTable();
            using (SpreadsheetDocument spreadSheetDocument = SpreadsheetDocument.Open(excelFilePath, false))
            {
                WorkbookPart workbookPart = spreadSheetDocument.WorkbookPart;
                IEnumerable<Sheet> sheets = spreadSheetDocument.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                string relationshipId = sheets.First().Id.Value;
                WorksheetPart worksheetPart = (WorksheetPart)spreadSheetDocument.WorkbookPart.GetPartById(relationshipId);
                Worksheet workSheet = worksheetPart.Worksheet;
                SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                IEnumerable<Row> rows = sheetData.Descendants<Row>();

                foreach (Cell cell in rows.ElementAt(0))
                {
                    dt.Columns.Add(GetCellValue(spreadSheetDocument, cell));
                }

                foreach (Row row in rows) //this will also include your header row...
                {
                    DataRow tempRow = dt.NewRow();

                    for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                    {
                        tempRow[i] = GetCellValue(spreadSheetDocument, row.Descendants<Cell>().ElementAt(i));
                    }

                    dt.Rows.Add(tempRow);
                }
            }
            dt.Rows.RemoveAt(0); //...so i'm taking it out here.
            return dt;
        }

        private string GetCellValue(SpreadsheetDocument document, Cell cell)
        {
            SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
            string value = cell.CellValue.InnerXml;

            if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
            {
                return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
            }
            else
            {
                return value;
            }
        }

        #endregion

        public string GetTemporaryDirectoryBasePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Temp/");
        }

        public string GetSQLiteDbFileDirectoryBasePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Data/DB_FILES/");
        }

        public string GetSQLiteQuestionsTemplateDatabaseFile()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Data/DB_FILES/QUE-DB-QUESTIONS.s3db");
        }

        public string GetRandomSQLiteDbFileName()
        {
            return string.Concat(DateTime.UtcNow.ToString("ddMMyyyyHHmmssfff_", System.Globalization.CultureInfo.InvariantCulture), Guid.NewGuid().ToString(), ".s3db").ToLower();
        }

        public string GetSystemDbFilePath()
        {
            return System.Web.Hosting.HostingEnvironment.MapPath("~/Data/DB_FILES/SYS-DB.s3db");
        }

        public List<string> GetAllRoles()
        {
            if (_roles == null)
            {
                _roles = new List<string>();
                _roles.AddRange(Enum.GetNames(typeof(AppUserRoles)));
            }
            return _roles;
        }

        public List<Company> GetAllCompanies()
        {
            return _systemDb.GetAllCompanies();
        }
    }

    #region Application Roles

    public enum AppUserRoles
    {
        SYSTEM_ADMIN,
        COMPANY_ADMIN,
        STUDENT,
        GUEST
    }

    #endregion
}