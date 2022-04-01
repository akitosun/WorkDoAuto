using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using NLog;
using Formatting = System.Xml.Formatting;

namespace Utility.Helper
{
    public class ApiHelper: IApiHelper
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private string _sessionId;
        private string _jsessionId;
        private CookieContainer cookieContainer;
        public string SessionId
        {
            get { return _sessionId; }
        }
        public string JSessionId
        {
            get { return _jsessionId; }
        }
        /// <summary>
        /// Get request for API
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        public async Task<T> GetRequestAsync<T>(string requestEndpoint, Dictionary<string, string> additionalHeaders)
        {
            using (var client = new HttpClient())
            {
                // Add additional headers
                AddHeaders(client, additionalHeaders);

                var httpResponseMessage = await client.GetAsync(requestEndpoint);
                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                logger.Info(response);
                return JsonConvert.DeserializeObject<T>(response, new JsonSerializerSettings());
            }
        }

        /// <summary>
        /// Get request for API
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <returns>deserialized object </returns>
        public async Task<T> GetRequestAsync<T>(string requestEndpoint)
        {
            return await this.GetRequestAsync<T>(requestEndpoint, null);
        }

        /// <summary>
        /// Post request for API with headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        public async Task<TResponseType> PostRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody, Dictionary<string, string> additionalHeaders)
        {
            using (var client = new HttpClient())
            {

                // Add additional headers
                AddHeaders(client, additionalHeaders);

                var json = JsonConvert.SerializeObject(requestBody);
                var httpContent = new StringContent(json);

                var httpResponseMessage = await client.PostAsync(requestEndpoint, httpContent);
                //_jsessionId = GetCookieValue(httpResponseMessage, "JSESSIONID");
                //_sessionId = GetCookieValue(httpResponseMessage, "sessionId");
                var response = await httpResponseMessage.Content.ReadAsStringAsync();
                logger.Info(response);
                return JsonConvert.DeserializeObject<TResponseType>(response);
            }
        }

        /// <summary>
        /// Post request for API without headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <returns>deserialized object </returns>
        public async Task<TResponseType> PostRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody)
        {
            return await this.PostRequestAsync<TRequestType, TResponseType>(requestEndpoint, requestBody, null);
        }

        public void PostRequest<TRequestType>(string requestEndpoint, TRequestType requestBody,
            Dictionary<string, string> additionalHeaders)
        {
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {

                // Add additional headers
                AddHeaders(client, additionalHeaders);
                
                var json = JsonConvert.SerializeObject(requestBody);
                var httpContent = new StringContent(json);
                
                var httpResponseMessage = client.PostAsync(requestEndpoint, httpContent).GetAwaiter().GetResult();
                cookieContainer = handler.CookieContainer;
                //_jsessionId = GetCookieValue(httpResponseMessage, "JSESSIONID");
               //_sessionId = GetCookieValue(httpResponseMessage, "sessionId");
                var response = httpResponseMessage.Content.ToString();
                logger.Info(response);
            }
        }
        /// <summary>
        /// Put request for API
        /// </summary>
        /// <typeparam name="TRequest">Request Type for deserialization</typeparam>
        /// <typeparam name="TResponse">Response Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        public async Task<TResponse> PutRequestAsync<TRequest, TResponse>(string requestEndpoint, TRequest requestBody, Dictionary<string, string> additionalHeaders)
        {
            using (var client = new HttpClient())
            {

                // Add additional headers
                AddHeaders(client, additionalHeaders);

                var json = JsonConvert.SerializeObject(requestBody);
                var httpContent = new StringContent(json);

                var httpResponseMessage = await client.PutAsync(requestEndpoint, httpContent);
                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<TResponse>(response);
            }
        }

        /// <summary>
        /// Put request for API
        /// </summary>
        /// <typeparam name="TRequest">Request Type for deserialization</typeparam>
        /// <typeparam name="TResponse">Response Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <returns>deserialized object </returns>
        public async Task<TResponse> PutRequestAsync<TRequest, TResponse>(string requestEndpoint, TRequest requestBody)
        {
            return await this.PutRequestAsync<TRequest, TResponse>(requestEndpoint, requestBody, null);
        }

        /// <summary>
        /// Delete request for API
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        public async Task<T> DeleteRequestAsync<T>(string requestEndpoint, Dictionary<string, string> additionalHeaders)
        {
            using (var client = new HttpClient())
            {

                // Add additional headers
                AddHeaders(client, additionalHeaders);

                var httpResponseMessage = await client.DeleteAsync(requestEndpoint);
                var response = await httpResponseMessage.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(response, new JsonSerializerSettings());
            }
        }

        /// <summary>
        /// Delete request for API
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <returns>deserialized object </returns>
        public async Task<T> DeleteRequestAsync<T>(string requestEndpoint)
        {
            return await this.DeleteRequestAsync<T>(requestEndpoint, null);
        }

        private static void AddHeaders(HttpClient httpClient, Dictionary<string, string> additionalHeaders)
        {
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            if (additionalHeaders == null)
            {
                return;
            }

            foreach (KeyValuePair<string, string> current in additionalHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(current.Key, current.Value);
            }
        }

        private string GetCookieValue(HttpResponseMessage message,string cookieKey)
        {
            message.Headers.TryGetValues("Set-Cookie", out var setCookie);
            var targetCookie=setCookie.FirstOrDefault(x=>x.Contains(cookieKey));
            if (string.IsNullOrEmpty(targetCookie)) return "";
            var cookie=targetCookie.Split(';').First(x=>x.Contains(cookieKey));
            var keyValue=cookie.Split('=');
            var valueString = keyValue[1];
            var cookieValue = HttpUtility.UrlDecode(valueString);
            return cookieValue;
        }
    }
}
