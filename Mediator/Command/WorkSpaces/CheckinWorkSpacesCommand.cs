using MediatR;
using System.Net.Http.Headers;
using TFGDevopsApp1.Common.Helpers;
using TFGDevopsApp1.Core.Models.Result;
using TFGDevopsApp1.Infraestructure.Entity.Plastic;

namespace TFGDevopsApp1.Mediator.Command.WorkSpaces
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
