using TFGDevopsApp.Common.Enum;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp.Infraestructure.Repository
{
    public interface IIssueTrackingRepository : IBaseRepository<IssueTracking>
    {
        Task<IssueTracking> GetByChangeSetIdAsync(int changeSetId, int type);
    }
}