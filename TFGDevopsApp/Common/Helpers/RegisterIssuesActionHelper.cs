using AutoMapper;
using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Common.Extensions;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Dtos.Mantis.Issues;
using TFGDevopsApp.Infraestructure.Entity.Mantis;
using TFGDevopsApp.Infraestructure.Repository;

namespace TFGDevopsApp.Common.Helpers
{
    public class RegisterIssuesActionHelper
    {
        private readonly IIssueTrackingRepository _issueTrackingRepository;
        private readonly IMapper _mapper;

        public RegisterIssuesActionHelper(IIssueTrackingRepository issueTrackingRepository,
                                          IMapper mapper)
        {
            _issueTrackingRepository = issueTrackingRepository;
            _mapper = mapper;
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

        public async Task<bool> RegisterPatchTask(long? issueId, int type, int changeSetId)
        {
            bool result = false;
            var currentIssueTracking = await _issueTrackingRepository.GetByChangeSetIdAsync(changeSetId, EnumIssueType.ChangeSet.ToInt());

            if (currentIssueTracking != null)
            {
                currentIssueTracking.Id = currentIssueTracking.Id;
                currentIssueTracking.RelatedIssueId = issueId;
               
                await _issueTrackingRepository.UpdateAsync(currentIssueTracking);
                result =  await _issueTrackingRepository.SaveChangeAsync();
            }

            return result;
        }

        public async Task<IssueTrackingResponseDto> GetIssueTrackingByChangeSetId(int changeSetId)
        {
            var issueTraking =  await _issueTrackingRepository.GetByChangeSetIdAsync(changeSetId, EnumIssueType.ChangeSet.ToInt());
            var result = _mapper.Map<IssueTrackingResponseDto>(issueTraking);
            return result;
        }
    }
}
