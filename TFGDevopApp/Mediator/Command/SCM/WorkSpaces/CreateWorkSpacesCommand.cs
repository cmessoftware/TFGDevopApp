using MediatR;
using System.Net.Http.Headers;
using TFGDevopsApp.Core.Models.Result;

namespace TFGDevopsApp.Services.Contributor.Command.SCM.WorkSpaces
{
    public class CreateWorkSpacesCommand : IRequest<ResultMessage<string>>
    {
        public static HttpClient GetHttpClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9090/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

    }
}
