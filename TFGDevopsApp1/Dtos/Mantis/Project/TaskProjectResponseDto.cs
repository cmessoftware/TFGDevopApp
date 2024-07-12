using Newtonsoft.Json;

namespace TFGDevopsApp.Interfaces
{
    public class TaskProjectResponseDto
    {
        [JsonProperty("projects")]
        public Core.Helpers.Project Project { get; set; }
    }
}