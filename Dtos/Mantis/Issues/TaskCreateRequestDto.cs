using TFGDevopsApp1.Core.Helpers;

namespace TFGDevopsApp1.Dtos.Mantis.Issues
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