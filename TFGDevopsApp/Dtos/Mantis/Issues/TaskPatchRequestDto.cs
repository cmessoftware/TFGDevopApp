using System.Runtime.InteropServices.Marshalling;
using System.Text.Json.Serialization;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{
    public class TaskPatchRequestDto
    {
        [JsonPropertyName("issue")]
        public ParentIssue issue { get; set; }

        [JsonPropertyName("type")]
        public RelationShipType type { get; set; }
        public int ChangeSetId { get; set; }
    }

    public class RelationShipType
    {
        [JsonPropertyName("name")]
        public string name { get; set; }
    }

    public class ParentIssue
    {
        [JsonPropertyName("id")]
        public long? id { get; set; }
    }


}