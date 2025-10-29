using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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

        private string _cookie;

        /// <summary>
        /// loginURL
        /// </summary>

        private static string punchURL = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/saveFromCreate102M3";
        private static string url_Login = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";
        private static string url_PunchStatus = "https://www.workdo.co/ccndweb/api/dweb/CCN102M/execute102M2FromMenu";
        private static string url_MissingPunchQuery = "https://www.workdo.co/ccnraweb/api/aweb/CCN002W/queryFromQuery002W1";


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

        public async Task<List<string>> QueryHoliday()
        {
            var vacationlist = new List<string>();

            try
            {
                var calendarUrl = ConfigHelper.GetInstance().GetAppSettingValue("HolidayCalendarUrl");

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(calendarUrl);
                request.Method = "GET";
                request.Accept = "text/calendar, */*";

                using (var response = (HttpWebResponse)await request.GetResponseAsync().ConfigureAwait(false))
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var calendarContent = reader.ReadToEnd();
                    vacationlist = ParseHolidayCalendar(calendarContent)
                        .Select(date => date.ToShortDateString())
                        .ToList();
                }
            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }

            return vacationlist;
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

        public Task<List<ClockPunchRecord>> QueryMissingPunchRecordsAsync()
        {
            var records = new List<ClockPunchRecord>();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url_MissingPunchQuery);
                request.Method = "POST";
                request.Host = "www.workdo.co";
                request.AllowAutoRedirect = false;
                request.ContentType = "application/json;charset=UTF-8";
                request.Accept = "application/json, text/plain, */*";
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.60 Safari/537.36";
                request.Headers.Add("tenant_id", "aa6pd97f");
                request.Headers.Add("timezone", "GMT+0800");
                request.Headers.Add("Accept-Language", "zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7");

                CookieContainer cookiecontainer = new CookieContainer();
                string[] cookies = _cookie.Split(';');
                foreach (string cookie in cookies)
                {
                    cookiecontainer.SetCookies(new Uri("https://www.workdo.co"), cookie);
                }

                request.CookieContainer = cookiecontainer;

                var requestPayload = new { displayName = "ClockPunchReq" };
                string postData = JsonConvert.SerializeObject(requestPayload);
                byte[] postBytes = Encoding.UTF8.GetBytes(postData);
                request.ContentLength = postBytes.Length;

                using (Stream postDataStream = request.GetRequestStream())
                {
                    postDataStream.Write(postBytes, 0, postBytes.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var responseJson = reader.ReadToEnd();
                    var queryResponse = JsonConvert.DeserializeObject<ClockPunchQueryResponse>(responseJson);
                    if (queryResponse?.list != null)
                    {
                        records = queryResponse.list;
                    }
                }

                response.Close();
            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }

            return Task.FromResult(records);
        }

        public async Task<bool> SupplementMissingPunchAsync(Enum_clocktype clockType)
        {
            try
            {
                List<ClockPunchRecord> records = await QueryMissingPunchRecordsAsync().ConfigureAwait(false);

                if (records == null || records.Count == 0)
                {
                    return false;
                }

                string today = DateTime.UtcNow.AddHours(8).ToString("yyyy-MM-dd");
                string targetType = clockType == Enum_clocktype.ClockIn ? "ClockIn" : "ClockOut";

                var missingRecords = records.Where(record =>
                        string.Equals(record.result, "Missing", StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(record.type, targetType, StringComparison.OrdinalIgnoreCase) &&
                        string.Equals(record.punchDay, today, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                if (missingRecords.Count == 0)
                {
                    return false;
                }

                foreach (var _ in missingRecords)
                {
                    if (clockType == Enum_clocktype.ClockIn)
                    {
                        PunchIn();
                    }
                    else
                    {
                        PunchOut();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                _logger.Debug(e);
                throw;
            }
        }

        private static List<DateTime> ParseHolidayCalendar(string calendarContent)
        {
            var holidays = new HashSet<DateTime>();

            if (string.IsNullOrWhiteSpace(calendarContent))
            {
                return new List<DateTime>();
            }

            calendarContent = calendarContent.Replace("\r\n ", string.Empty).Replace("\n ", string.Empty);

            using (var reader = new StringReader(calendarContent))
            {
                string line;
                DateTime? start = null;
                DateTime? end = null;
                bool startIsDateOnly = false;
                bool endIsDateOnly = false;
                bool skipEvent = false;

                while ((line = reader.ReadLine()) != null)
                {
                    line = line.Trim();

                    if (line.StartsWith("BEGIN:VEVENT", StringComparison.OrdinalIgnoreCase))
                    {
                        start = null;
                        end = null;
                        startIsDateOnly = false;
                        endIsDateOnly = false;
                        skipEvent = false;
                    }
                    else if (line.StartsWith("DTSTART", StringComparison.OrdinalIgnoreCase))
                    {
                        start = TryParseCalendarDate(line, out startIsDateOnly);
                    }
                    else if (line.StartsWith("DTEND", StringComparison.OrdinalIgnoreCase))
                    {
                        end = TryParseCalendarDate(line, out endIsDateOnly);
                    }
                    else if (line.StartsWith("SUMMARY", StringComparison.OrdinalIgnoreCase))
                    {
                        var summaryValue = line.Split(new[] { ':' }, 2).LastOrDefault()?.Trim();

                        if (!string.IsNullOrEmpty(summaryValue) &&
                            summaryValue.IndexOf("Monthly Step-Up Challenge", StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            skipEvent = true;
                        }
                    }
                    else if (line.StartsWith("END:VEVENT", StringComparison.OrdinalIgnoreCase))
                    {
                        if (skipEvent)
                        {
                            continue;
                        }

                        if (!start.HasValue)
                        {
                            continue;
                        }

                        var startDate = start.Value.Date;
                        var endDate = startDate;

                        if (end.HasValue)
                        {
                            endDate = end.Value.Date;

                            if (endIsDateOnly || (end.Value.TimeOfDay == TimeSpan.Zero && endDate > startDate))
                            {
                                endDate = endDate.AddDays(-1);
                            }
                        }

                        if (endDate < startDate)
                        {
                            endDate = startDate;
                        }

                        for (var date = startDate; date <= endDate; date = date.AddDays(1))
                        {
                            holidays.Add(date);
                        }
                    }
                }
            }

            return holidays.OrderBy(date => date).ToList();
        }

        private static DateTime? TryParseCalendarDate(string line, out bool isDateOnly)
        {
            isDateOnly = line.IndexOf("VALUE=DATE", StringComparison.OrdinalIgnoreCase) >= 0;
            var segments = line.Split(':');

            if (segments.Length < 2)
            {
                return null;
            }

            var value = segments[segments.Length - 1].Trim();

            if (isDateOnly)
            {
                if (DateTime.TryParseExact(value, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var dateValue))
                {
                    return dateValue;
                }

                return null;
            }

            string[] formats = { "yyyyMMdd'T'HHmmss'Z'", "yyyyMMdd'T'HHmmss", "yyyyMMdd" };

            if (DateTime.TryParseExact(value, formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out var dateTimeValue))
            {
                return dateTimeValue;
            }

            return null;
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
