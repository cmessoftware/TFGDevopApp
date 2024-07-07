using TFGDevopsApp1.Core.Helpers;

namespace TFGDevopsApp1.Dtos.Mantis.Issues
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