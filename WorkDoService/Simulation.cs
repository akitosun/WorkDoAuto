using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;

using Utility.Helper;

using WorkDoService.Models;

namespace WorkDoService
{
    public class Simulation : ISimulation
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Get Email from app.configuration
        /// </summary>
        private string _email = ConfigHelper.GetInstance().GetAppSettingValue("Email");

        /// <summary>
        /// Get Password from app.configuration
        /// </summary>
        private string _password = ConfigHelper.GetInstance().GetAppSettingValue("Pw");
        private string workday = ConfigHelper.GetInstance().GetAppSettingValue("WorkDay");

        private string _cookie;

        /// <summary>
        /// loginURL
        /// </summary>
        private string loginURL = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";

        private string punchURL = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/saveFromCreate102M3";


        private static string url_Login = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";
        private static string url_Punch = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/saveFromCreate102M3";
        private static string url_Calendar = "http://www.workdo.co/hrsraweb/api/aweb/HRS003W/execute003W3FromMenu";
        private static string url_PunchStatus = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/execute102M2FromMenu";


        HolidayData latest_holiday = new HolidayData();

        public bool IsNotLogin()
        {
            return string.IsNullOrEmpty(_cookie);
        }



        public void LoginSimulation()
        {


            var loginData = new LoginData();
            loginData.clientType = "Web";
            loginData.clientModel = "Chrome 100.0.4896.127";
            loginData.clientOs = "Windows 10";
            loginData.appVersion = "wd_aweb_6.5.5";
            loginData.timeZone = "GMT+0800";
            loginData.loginEmail = _email;
            loginData.password = _password;
            loginData.loginId = _email;
            var PostData = JsonConvert.SerializeObject(loginData);
            //1.獲取登錄Cookie
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_Login);
            request.Method = "POST";// POST OR GET， 如果是GET, 則沒有第二步傳參，直接第三步，獲取服務端返回的數據
            request.AllowAutoRedirect = false;//服務端重定向。一般設置false
            request.ContentType = "application/json;charset=UTF-8";
            byte[] postBytes = Encoding.UTF8.GetBytes(PostData);
            request.ContentLength = postBytes.Length;
            Stream postDataStream = request.GetRequestStream();
            postDataStream.Write(postBytes, 0, postBytes.Length);
            postDataStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            _cookie = response.Headers.Get("Set-Cookie"); //獲取登錄後的cookie值。
            response.Close();
        }

        public Task<List<string>> QueryHoliday()
        {
            List<string> vacationlist = new List<string>();

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_Calendar);
                request.Method = "GET";
                request.Accept = "application/json, text/plain, */*";
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36";
                request.Headers.Add("tenant_id", "aa6pd97f");
                request.ContentLength = 0;

                CookieContainer cookiecontainer = new CookieContainer();
                string[] cookies = _cookie.Split(';');

                foreach (string cookie in cookies)
                    cookiecontainer.SetCookies(new Uri("https://www.workdo.co"), cookie);

                request.CookieContainer = cookiecontainer;


                var response = (HttpWebResponse)request.GetResponse();
                //Stream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                Stream stream = response.GetResponseStream();

                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                JObject jobject = JObject.Parse(reader.ReadToEnd());
                vacationlist = jobject.Value<JArray>("futureCalendarList").Select(x => DateTime.Parse(x["eventDate"].ToString()).ToShortDateString()).ToList();
                response.Close();

            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }

            return Task.FromResult(vacationlist);
        }


        public Task<PunchHistory> Query_PunchHistory(Enum_clocktype enum_Clocktype)   //Query Today Punch history
        {
            var punchHistory = new PunchHistory();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_PunchStatus);
                request.Method = "POST";
                request.Host = "www.workdo.co";
                request.AllowAutoRedirect = false;  //服務端重定向。一般設置false
                request.ContentType = "application/json;charset=UTF-8";
                request.Accept = "application/json, text/plain, */*";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
                request.Headers.Add("tenant_id", "aa6pd97f");
                request.Headers.Add("timezone", "GMT+0800");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                request.ContentLength = 0;
                CookieContainer cookiecontainer = new CookieContainer();
                string[] cookies = _cookie.Split(';');
                foreach (string cookie in cookies)
                    cookiecontainer.SetCookies(new Uri("https://www.workdo.co"), cookie);
                request.CookieContainer = cookiecontainer;




                var response = (HttpWebResponse)request.GetResponse();
                //Stream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);

                JObject response_Json = JObject.Parse(reader.ReadToEnd());

                if (enum_Clocktype == Enum_clocktype.ClockIn)
                {
                    punchHistory = JsonConvert.DeserializeObject<PunchHistory>(response_Json["list"][0].ToString());
                }
                else
                {
                    punchHistory = JsonConvert.DeserializeObject<PunchHistory>(response_Json["list"][1].ToString());
                }

                response.Close();

            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }
            return Task.FromResult(punchHistory);
        }


        public void PunchIn()
        {
            Punch("ClockIn");
        }
        public void PunchOut()
        {
            Punch("ClockOut");
        }

        private void Punch(string punchType)
        {
            try
            {

                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(punchURL);
                req.Method = "POST";
                req.Host = "www.workdo.co";
                req.AllowAutoRedirect = false;//服務端重定向。一般設置false
                req.ContentType = "application/json;charset=UTF-8";
                req.Accept = "application/json, text/plain, */*";
                req.UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
                req.Headers.Add("tenant_id", "aa6pd97f");
                req.Headers.Add("timezone", "GMT+0800");
                req.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                req.Headers.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");
                CookieContainer cookiecontainer = new CookieContainer();
                string[] cookies = _cookie.Split(';');
                foreach (string cookie in cookies)
                    cookiecontainer.SetCookies(new Uri("https://www.workdo.co"), cookie);
                req.CookieContainer = cookiecontainer;
                var requestData = new PunchData();
                requestData.type = punchType;
                requestData.place = "OtherCity";
                requestData.gpsLocation = new Gpslocation() { text = ConfigHelper.GetInstance().GetAppSettingValue("gpsLocation") };
                requestData.gpsPlace = ConfigHelper.GetInstance().GetAppSettingValue("gpsPlace");
                string postData = JsonConvert.SerializeObject(requestData);
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                req.ContentLength = postBytes.Length;
                Stream postDataStream = req.GetRequestStream();
                postDataStream.Write(postBytes, 0, postBytes.Length);
                postDataStream.Close();
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }
        }
    }
}
