using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Xsl;
using System.Web.Mvc;

namespace Web.Helper
{
    public class Utility
    {
        public void ToXml(String GridData, String fileName = null)
        {
            XmlNode xml = XmlFromJsonString(GridData);
            string strXml = xml.OuterXml;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename="+(fileName??"TransactionData.xml"));
            HttpContext.Current.Response.AddHeader("Content-Length", strXml.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/xml";
            HttpContext.Current.Response.Write(strXml);
            HttpContext.Current.Response.End();
        }

        public void ToExcel(String GridData, String fileName = null)
        {
            XmlNode xml = XmlFromJsonString(GridData);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + (fileName ?? "TransactionData.xls"));
            XslCompiledTransform xtExcel = new XslCompiledTransform();
            xtExcel.Load(HttpContext.Current.Server.MapPath("~/Helper/SchemaFiles/Excel.xsl"));
            xtExcel.Transform(xml, null, HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.End();
        }

        public void ToCsv(String GridData, String fileName = null)
        {
            XmlNode xml = XmlFromJsonString(GridData);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/octet-stream";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + (fileName ?? "TransactionData.csv"));
            XslCompiledTransform xtCsv = new XslCompiledTransform();
            xtCsv.Load(HttpContext.Current.Server.MapPath("~/Helper/SchemaFiles/Csv.xsl"));
            xtCsv.Transform(xml, null, HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.End();
        }

        public XmlNode XmlFromJsonString(String jsonString)
        {
            return JsonConvert.DeserializeXmlNode("{records:{record:" + jsonString + "}}");
        }
    }
}