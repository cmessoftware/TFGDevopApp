using Newtonsoft.Json;

namespace TFGDevopsApp.Dtos.Plastic.Repositories
{
    public class CreateRepositoryRequestDto
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("MachineName")]
        public string MachineName { get; set; }

        [JsonProperty("Comment")]
        public string Comment { get; set; }
        public DateTime CreationDate { get; internal set; }
    }
}