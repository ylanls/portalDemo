using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace portal.Util
{
    public class Util
    {
        public static string GetAuthString()
        {
            var stamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            var AccountId = ConfigurationManager.AppSettings["AccountId"].ToString();
            var AuthToken = ConfigurationManager.AppSettings["AuthToken"].ToString();
            var md = MD5.Create();
            byte[] data = md.ComputeHash(Encoding.UTF8.GetBytes(AccountId + AuthToken + stamp));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x"));
            }
            var result = "&timestamp=" + stamp + "&sig=" + sBuilder.ToString() + "&respDataType=json";
            return result;
        }
        public static HttpWebResponse Post(string url, string body)
        {
            HttpWebRequest request = null;
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            byte[] data = Encoding.UTF8.GetBytes(body);
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            string[] values = request.Headers.GetValues("Content-Type");
            return request.GetResponse() as HttpWebResponse;
        }
        public static SqlConnection GetDBConnection()
        {
            var connnectStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connnectStr);
            return conn;
        }
    }
}
