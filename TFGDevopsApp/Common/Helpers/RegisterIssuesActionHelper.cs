using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Infraestructure.Entity.Mantis;
using TFGDevopsApp.Infraestructure.Repository;

namespace TFGDevopsApp.Common.Helpers
{
    public class RegisterIssuesActionHelper
    {
        private readonly IIssueTrackingRepository _issueTrackingRepository;

        public RegisterIssuesActionHelper(IIssueTrackingRepository issueTrackingRepository)
        {
            _issueTrackingRepository = issueTrackingRepository;
        }

        public async Task<bool> RegisterCreateTask(Issue issue, int? type, int? changeSetId = null, int? relatedIssueId = null)
        {
            //var issueTracking = _mapper.Map<IssueTracking>(issue);
            var issueTracking = new IssueTracking()
            {
                IssueId = issue.Id,
                Summary = issue.Summary,
                Description = issue.Description,
                Status = "new",
                RelatedIssueId = relatedIssueId,
                Priority = issue.Priority.Name,
                Project = issue.Project.Name,
                Category = issue.Category.Name,
                Type = type,
                ChangeSetId = changeSetId,
            };
            await _issueTrackingRepository.CreateAsync(issueTracking);
            return await _issueTrackingRepository.SaveChangeAsync();

        }
    }
}
