using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Lesson_Part2.Services
{
    public class HtmlService
    {
        public static async Task<int> CountAsync(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse =await myRequest.GetResponseAsync();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return result.Count();
        }
        public static int Count(string Url)
        {

            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(Url);
            myRequest.Method = "GET";
            WebResponse myResponse = myRequest.GetResponse();
            StreamReader sr = new StreamReader(myResponse.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = sr.ReadToEnd();
            sr.Close();
            myResponse.Close();
            return result.Count();
        }
        static int cc(string url){
            HttpWebRequest request =(HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            WebResponse response = request.GetResponse();
            StreamReader sr=new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
            string htmlresult=sr.ReadToEnd();
            sr.Close();
            response.Close();
            return htmlresult.Count();
        }



}
}