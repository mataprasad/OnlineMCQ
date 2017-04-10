using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;


namespace Web.Helper
{
    public static class Utility
    {
        public static void ToXml(String GridData, String fileName = null)
        {
            XmlNode xml = XmlFromJsonString(GridData);
            string strXml = xml.OuterXml;
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + (fileName ?? "TransactionData.xml"));
            HttpContext.Current.Response.AddHeader("Content-Length", strXml.Length.ToString());
            HttpContext.Current.Response.ContentType = "application/xml";
            HttpContext.Current.Response.Write(strXml);
            HttpContext.Current.Response.End();
        }

        public static void ToExcel(String GridData, String fileName = null)
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

        public static void ToCsv(String GridData, String fileName = null)
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

        public static XmlNode XmlFromJsonString(String jsonString)
        {
            return JsonConvert.DeserializeXmlNode("{records:{record:" + jsonString + "}}");
        }

        public static int GetCurrentDateInt()
        {
            return int.Parse(DateTime.UtcNow.ToString("yyyyMMdd"));
        }

        public static int GetCurrentTimeInt()
        {
            return int.Parse(DateTime.UtcNow.ToString("HHmmssfff"));
        }

        public static string SerializeToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter stringWriter = null;
            using (stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize((TextWriter)stringWriter, (object)obj);
                stringWriter.Close();
            }
            xmlSerializer = null;
            return Convert.ToString((object)stringWriter);
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            using (TextReader textReader = (TextReader)new StringReader(xml))
                return (T)new XmlSerializer(typeof(T)).Deserialize(textReader);
        }

        public static string Encrypt(string toEncrypt, bool useHashing = true)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(toEncrypt);
            AppSettingsReader appSettingsReader = new AppSettingsReader();
            string s = "SyeM atahiur Murshed";
            byte[] numArray;
            if (useHashing)
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
                numArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
                cryptoServiceProvider.Clear();
            }
            else
                numArray = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider1.Key = numArray;
            cryptoServiceProvider1.Mode = CipherMode.ECB;
            cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
            byte[] inArray = cryptoServiceProvider1.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
            cryptoServiceProvider1.Clear();
            return Convert.ToBase64String(inArray, 0, inArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing = true)
        {
            byte[] inputBuffer = Convert.FromBase64String(cipherString);
            AppSettingsReader appSettingsReader = new AppSettingsReader();
            string s = "SyeM atahiur Murshed";
            byte[] numArray;
            if (useHashing)
            {
                MD5CryptoServiceProvider cryptoServiceProvider = new MD5CryptoServiceProvider();
                numArray = cryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
                cryptoServiceProvider.Clear();
            }
            else
                numArray = Encoding.UTF8.GetBytes(s);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            cryptoServiceProvider1.Key = numArray;
            cryptoServiceProvider1.Mode = CipherMode.ECB;
            cryptoServiceProvider1.Padding = PaddingMode.PKCS7;
            byte[] bytes = cryptoServiceProvider1.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
            cryptoServiceProvider1.Clear();
            return Encoding.UTF8.GetString(bytes);
        }

        public static string GetCaptchaCode()
        {
            string strString = "ABCDEFGHJKLMNOPQRSTUVWXYZ23456789";
            Random random = new Random();
            int randomCharIndex = 0;

            string captcha = "";
            for (int i = 0; i < 7; i++)
            {
                randomCharIndex = random.Next(0, strString.Length);
                captcha += Convert.ToString(strString[randomCharIndex]);
            }
            return captcha.Trim().ToUpper();
        }
    }
}