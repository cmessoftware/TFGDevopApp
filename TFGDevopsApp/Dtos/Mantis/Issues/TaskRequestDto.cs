using TFGDevopsApp.Core.Helpers;

namespace TFGDevopsApp.Dtos.Mantis.Issues
{
    public class TaskRequestDto
    {

        public TaskRequestDto(Issue issue)
        {
            Issue = issue;
        }

        public Issue Issue { get; set; }
    }
}