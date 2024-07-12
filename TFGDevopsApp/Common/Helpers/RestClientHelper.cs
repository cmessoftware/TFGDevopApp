using Newtonsoft.Json;
using RestSharp;
using System.Net;
using System.Text;
using TFGDevopsApp.Common.Exceptions;
using TFGDevopsApp.Common.Extensions;

namespace TFGDevopsApp.Common.Helpers
{
    public class RestClientHelper
    {

        public static async Task<R> AuthorizedPostAsync<R, T>(string url, T request, string? authToken)
        {
            R data = default;

            var client = new RestClient(url);
            if (!string.IsNullOrEmpty(authToken))
                client.AddDefaultHeader("Authorization", authToken);

            IRestResponse response = client.Post(request, url);

            if (response != null && 
               (response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Created))
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.Content}: {response.ErrorMessage}");
            }

            return data;
        }


        public static R Post<R, T>(string apiPath, string requestData)
        {
            R data = default;

            var client = new RestClient(apiPath);

            IRestResponse response = client.Post(requestData, apiPath);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

        public static R Post<R, T>(string apiPath, T requestData)
        {
            R data = default;

            var client = new RestClient(apiPath);

            IRestResponse response = client.Post(requestData, apiPath);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage} - {response.Content}");
            }

            return data;
        }

        public static R Get<R, T>(string apiPath, T requestData)
        {
            R data = default;

            var client = new RestClient(apiPath);

            IRestResponse response = client.Get(apiPath, requestData);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

        public static Task<R> AuthorizedGetAsync<R>(string apiPath, string authToken = "")
        {
            R data = default;

            var client = new RestClient(apiPath);

            if (!string.IsNullOrEmpty(authToken))
                client.AddDefaultHeader("Authorization", authToken);

            IRestResponse response = client.Get(apiPath);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return Task.FromResult(data);
        }



        public static R Get<R, T>(string apiPath)
        {
            R data = default;

            var client = new RestClient(apiPath);

            IRestResponse response = client.Get<T>(apiPath);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

        public static async Task<R> GetAsync<R>(string apiPath)
        {
            R data = default;

            string url = apiPath;

            var client = new RestClient(url);

            IRestResponse response = client.Get(url);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return await Task.FromResult(data);
        }

        public static R Get<R>(string apiPath)
        {
            R data = default;

            string url = apiPath;

            var client = new RestClient(url);

            IRestResponse response = client.Get(url);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

        public static R Get<R>(string apiPath, string parametros)
        {
            R data = default;

            string url = apiPath + parametros;

            var client = new RestClient(url);

            IRestResponse response = client.Get(url);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

        public static R GetBlob<R>(string url)
        {
            var client = new RestClient(url);

            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                byte[] blobData = response.RawBytes;

                if (typeof(R) == typeof(string))
                {
                    string result = Encoding.UTF8.GetString(blobData);
                    return (R)(object)result;
                }
                else
                {
                    return (R)Convert.ChangeType(blobData, typeof(R));
                }

            }

            return default(R);
        }

        public static R Delete<R, T>(string apiPath, T input)
        {
            R data = default;

            var url = $"{apiPath}/{input}";

            var client = new RestClient(url);

            var request = new RestRequest(Method.DELETE);

            IRestResponse response = client.Delete(request);

            if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                data = JsonConvert.DeserializeObject<R>(response.Content);
            }
            else
            {
                throw new RestClientException($"Error: {response.StatusCode} - {response.ErrorMessage}");
            }

            return data;
        }

    }
}
