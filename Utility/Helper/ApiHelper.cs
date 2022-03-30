using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Formatting = System.Xml.Formatting;

namespace Utility.Helper
{
    public class ApiHelper: IApiHelper
    {
        /// <summary>
        /// Email
        /// </summary>
        private string Email = ConfigHelper.GetInstance().GetAppSettingValue("Email");

        /// <summary>
        /// Secret Text
        /// </summary>
        private string SecretText = ConfigHelper.GetInstance().GetAppSettingValue("Pw");

        /// <summary>
        /// loginURL
        /// </summary>
        private string loginURL = "https://www.workdo.co/bdddweb/api/dweb/BDD771M/userLogin";
        
        

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
                var response = await httpResponseMessage.Content.ReadAsStringAsync();

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
        
    }
}
