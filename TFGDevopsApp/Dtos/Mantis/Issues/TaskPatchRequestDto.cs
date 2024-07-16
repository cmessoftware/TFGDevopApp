using System.Runtime.InteropServices.Marshalling;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{
    public class TaskPatchRequestDto
    {
        public int RelatedIssueId { get; set; }
        public int ParentIssueId { get; set; }

        public int ChangeSetId { get; set; }
        public string Type { get; set; } = "related-to";
    }
}