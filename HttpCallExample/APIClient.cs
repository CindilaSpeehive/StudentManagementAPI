//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;

//namespace HttpCallExample
//{
//    internal class APIClient
//    {
//        internal static async Task<HttpResponseMessage> DoGet(string endpoint, Dictionary<string, object> headers, EndpointOf api)
//        {
//            HttpClient client = CreateHttpClient();
//            client = await SetRequestHeader(headers, client);
//            return await ExecuteGet(CreateRequestURI(endpoint, api), client);
//        }

//        private static HttpClient CreateHttpClient()
//        {
//            HttpClient? client = new HttpClient();
//           // client.MaxResponseContentBufferSize = _config.APIInfo.MaxBufferSize;
//           // client.Timeout = TimeSpan.FromMilliseconds(_config.APIInfo.Timeout);
//            return client;
//        }

//        private static async Task<HttpClient> SetRequestHeader(Dictionary<string, object> headers, HttpClient client)
//        {
//            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", "Token"));
//            return client;
//        }

//        private static async Task<HttpResponseMessage> ExecuteGet(Uri endpoint, HttpClient client)
//        {
//            return await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead);
//        }

//        public static async Task<HttpResponseMessage> DoPost(string endpoint, object body, Dictionary<string, object> headers, EndpointOf api)
//        {
            
           
//                HttpClient client = CreateHttpClient();
//                client = await SetRequestHeader(headers, client);
//                return await ExecutePost(CreateRequestURI(endpoint, api), client, await SetHttpContent(headers, body));
           
//        }



//        private static Uri CreateRequestURI(string endpoint)
//        {
//            //string url = null;
//           // url = 
//            return new Uri(endpoint);
//        }
//    }
//}
