using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Core.Helpers;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{

    public class TaskCreateRequestDto
    {
        public TaskCreateRequestDto(Issue issue, EnumIssueType type, int changeSetId)
        {
            Issue = issue;
            Type = type;
            ChangeSetId = changeSetId;
        }
        public Issue Issue { get; set; } = new();
        public EnumIssueType Type { get; set; }
        public int ChangeSetId { get; }
    }

}