using TFGDevopsApp.Core.Helpers;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{

    public class TaskCreateRequestDto
    {
        public TaskCreateRequestDto(Issue issue)
        {
            Issue = issue;
        }
        public Issue Issue { get; set; } = new Issue();
    }

}