using MediatR;
using System.Net.Http.Headers;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Infraestructure.Entity.Plastic;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CheckinWorkSpacesCommand : IRequest<Result<string>>
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
        public static async Task<List<WorkSpace>> MostrarWorkSpaces()
        {
            var path = "/api/v1/wkspaces";
            var response = RestClientHelper.Get<List<WorkSpace>>(path);
            return await Task.FromResult(response);
        }

    }
}
