using System.Net;
using System.Text;

namespace WebApi.Client.Models
{
    public class HttpRequestHelper
    {
        // appsettings.json dosyası'nı temsil eder



        public bool SendRequest(string url, string httpReqestMetot, string parameter, string body, out string responseBody)
        {
            try
            {
                if (parameter != null)
                {
                    url = $"{url}{parameter}";
                }

                HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
                httpRequest.Method = httpReqestMetot;

                if (body != null)
                {
                    string postData = body;
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    byte[] byte1 = encoding.GetBytes(postData);
                    httpRequest.ContentLength = byte1.Length;
                    httpRequest.ContentType = "application/json";

                    Stream newStream = httpRequest.GetRequestStream();
                    newStream.Write(byte1, 0, byte1.Length);
                }

                WebResponse response = httpRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string result = reader.ReadToEnd();
                responseBody = result;
                return true;
            }
            catch (Exception ex)
            {
                responseBody = "";
                return false;
            }
        }
    }
}