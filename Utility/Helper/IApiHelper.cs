using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Helper
{
    /// <summary>
    /// API Helper Interface
    /// </summary>
    public interface IApiHelper
    {
        /// <summary>
        /// Get request for API with headers
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        Task<T> GetRequestAsync<T>(string requestEndpoint, Dictionary<string, string> additionalHeaders);

        /// <summary>
        /// Get request for API without headers
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <returns>deserialized object </returns>
        Task<T> GetRequestAsync<T>(string requestEndpoint);

        /// <summary>
        /// Post request for API with headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        Task<TResponseType> PostRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody, Dictionary<string, string> additionalHeaders);

        /// <summary>
        /// Post request for API without headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <returns>deserialized object </returns>
        Task<TResponseType> PostRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody);

        /// <summary>
        /// Put request for API with headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        Task<TResponseType> PutRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody, Dictionary<string, string> additionalHeaders);

        /// <summary>
        /// Put request for API without headers
        /// </summary>
        /// <typeparam name="TRequestType">RequestType Type for deserialization</typeparam>
        /// <typeparam name="TResponseType">ResponseType Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="requestBody">request body to be posted</param>        
        /// <returns>deserialized object </returns>
        Task<TResponseType> PutRequestAsync<TRequestType, TResponseType>(string requestEndpoint, TRequestType requestBody);

        /// <summary>
        /// Delete request for API with Headers
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <param name="additionalHeaders">Optional Header collection</param>
        /// <returns>deserialized object </returns>
        Task<T> DeleteRequestAsync<T>(string requestEndpoint, Dictionary<string, string> additionalHeaders);

        /// <summary>
        /// Delete request for API without Headers
        /// </summary>
        /// <typeparam name="T">Type for deserialization</typeparam>
        /// <param name="requestEndpoint">URI for service call</param>
        /// <returns>deserialized object </returns>
        Task<T> DeleteRequestAsync<T>(string requestEndpoint);
    }
}
