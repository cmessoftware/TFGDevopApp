using Newtonsoft.Json;
using RestSharp;

namespace TFGDevopsApp.Common.Extensions
{
    public static class RestClientExtensions
    {
        public static IRestResponse Post(this RestClient client, string body, string uri = null)
        {

            client.BaseUrl = client.BaseUrl ?? new Uri(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse Post<T>(this RestClient client, T body, string uri = null)
        {

            client.BaseUrl = client.BaseUrl ?? new Uri(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;

        }


        public static IRestResponse Get(this RestClient client, string uri)
        {

            client.BaseUrl = client.BaseUrl ?? new Uri(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse Get<T>(this RestClient client, string uri, T body)
        {

            client.BaseUrl = client.BaseUrl ?? new Uri(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var jsonBody = JsonConvert.SerializeObject(body);
            request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            IRestResponse response = client.Execute(request);

            return response;

        }

        public static IRestResponse Get<T>(this RestClient client, string uri)
        {

            client.BaseUrl = client.BaseUrl ?? new Uri(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Content-Type", "application/json; charset=utf-8");
            IRestResponse response = client.Execute(request);

            return response;

        }
    }
}
