using System.Net.Http.Headers;
using TFGDevopsApp.Core.Models.Result;
using TFGDevopsApp.Common.Helpers;
using TFGDevopsApp.Infraestructure.Entity.Plastic;
using MediatR;
using System.Net.Http;
using System.Threading.Tasks;

namespace TFGDevopsApp.Mediator.Command.WorkSpaces
{
    public class CheckinWorkSpacesCommand : IRequest<ResultMessage<string>>
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
