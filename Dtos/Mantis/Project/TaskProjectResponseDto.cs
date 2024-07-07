using Newtonsoft.Json;

namespace TFGDevopsApp1.Interfaces
{
    public class TaskProjectResponseDto
    {
        [JsonProperty("projects")]
        public Core.Helpers.Project Project { get; set; }
    }
}