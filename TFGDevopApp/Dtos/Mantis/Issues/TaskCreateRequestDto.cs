using TFGDevopsApp.Core.Helpers;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{

    public class TaskCreateRequestDto
    {
        public Issue TaskIssue { get; set; } = new Issue();
    }

}