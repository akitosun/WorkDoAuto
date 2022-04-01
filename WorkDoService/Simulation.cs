using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using NLog;

using Utility.Helper;

using WorkDoService.Models;

namespace WorkDoService
{
    public class Simulation
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// Email
        /// </summary>
        private string _email = ConfigHelper.GetInstance().GetAppSettingValue("Email");

        /// <summary>
        /// Secret Text
        /// </summary>
        private string _password = ConfigHelper.GetInstance().GetAppSettingValue("Pw");

        private string _cookie;
        /// <summary>
        /// loginURL
        /// </summary>
        private string loginURL = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";

        private string punchURL = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/saveFromCreate102M3";
        public void LoginSimulation()
        {
            string url = loginURL;
            var loginData = new LoginData();
            loginData.clientType = "Web";
            loginData.clientModel = "Chrome 100.0.4896.60";
            loginData.clientOs = "Windows 10";
            loginData.appVersion = "wd_aweb_6.5.5";
            loginData.timeZone = "GMT+0800";
            loginData.loginEmail = _email;
            loginData.password = _password;
            loginData.loginId = _email;
            string postData = JsonConvert.SerializeObject(loginData);

            //1.獲取登錄Cookie
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";// POST OR GET， 如果是GET, 則沒有第二步傳參，直接第三步，獲取服務端返回的數據
            req.AllowAutoRedirect = false;//服務端重定向。一般設置false
            req.ContentType = "application/json;charset=UTF-8";
            byte[] postBytes = Encoding.UTF8.GetBytes(postData);
            req.ContentLength = postBytes.Length;
            Stream postDataStream = req.GetRequestStream();
            postDataStream.Write(postBytes, 0, postBytes.Length);
            postDataStream.Close();

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            string cookies = resp.Headers.Get("Set-Cookie");//獲取登錄後的cookie值。
            _cookie= cookies; 

        }
        public void PunchIn()
        {
            Punch("ClockIn");

        }
        public void PunchOut()
        {
            Punch("ClockOut");
        }

        public void Punch(string punchType)
        {
            try
            {

                var apiHelper=new ApiHelper();
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(punchURL);
                req.Method = "POST";
                req.Host = "www.workdo.co";
                //req.Connection = "keep-alive";
                req.AllowAutoRedirect = false;//服務端重定向。一般設置false
                req.ContentType = "application/json;charset=UTF-8";
                req.Accept = "application/json, text/plain, */*";
                req.UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
                //req.Headers.Add("Accept", "application/json, text/plain, */*");
                req.Headers.Add("sec-ch-ua", "\" Not A; Brand\";v=\"99\", \"Chromium\";v=\"100\", \"Google Chrome\";v=\"100\"");
                req.Headers.Add("sec-ch-ua-mobile", "?0");
                req.Headers.Add("userLocale", "zh_TW");
                req.Headers.Add("app_version_code", "wd_aweb_6.5.5");
                req.Headers.Add("tenant_id", "aa6pd97f");
                req.Headers.Add("timezone", "GMT+0800");
                req.Headers.Add("sec-ch-ua-platform", "Windows");
                req.Headers.Add("Origin", "https://www.workdo.co");
                req.Headers.Add("Sec-Fetch-Site", "same-origin");
                req.Headers.Add("Sec-Fetch-Mode", "cors");
                req.Headers.Add("Sec-Fetch-Dest", "empty");
                req.Referer =
                    "https://www.workdo.co/ccnaweb/canvas.jsp?tenantId=aa6pd97f&svrVersionNo=wd_aweb_6.5.5&teamNameUsed=UserDispName&maxFileSize=20&brandName=WorkDo&isFromChina=false&baiduMapToken=sXFfhVn8bmQYohgAuFg0y9YGKq6AiROz&selfUid=aajiqi65ug&bigGroupThreshold=4000";
                //req.Headers.Add("Referer", "https://www.workdo.co/ccnaweb/canvas.jsp?tenantId=aa6pd97f&svrVersionNo=wd_aweb_6.5.5&teamNameUsed=UserDispName&maxFileSize=20&brandName=WorkDo&isFromChina=false&baiduMapToken=sXFfhVn8bmQYohgAuFg0y9YGKq6AiROz&selfUid=aajiqi65ug&bigGroupThreshold=4000");
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
            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }
        }
    }
}
