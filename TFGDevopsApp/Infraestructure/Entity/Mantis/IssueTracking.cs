using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Infraestructure.Entity;

namespace TFGDevopsApp.Infraestructure.Entity.Mantis
{
    public class IssueTracking : BaseEntity
    {
        public long? IssueId { get; set; }

        public int? ChangeSetId { get; set; }

        public int? Type { get; set; }

        public long? RelatedIssueId { get; set; }

        public string Summary { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = "new";

        public string Priority { get; set; }

        public string Project { get; set; }

        public string? Assignee { get; set; }

        public string? Reporter { get; set; }

        public string Category { get; set; }



    }
}