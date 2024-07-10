using TFGDevopsApp1.Data;
using TFGDevopsApp1.Infraestructure.Entity.Mantis;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Infraestructure.Repository
{
    public class IssueRepository : BaseRepository<IssueEntity>, IIssueRepository
    {
        public IssueRepository(ApplicationDbContext context) 
            : base(context)
        {
        }

        public async Task<IssueEntity> CreateAsync(IssueEntity model)
        {
            return await base.CreateAsync(model);
        }

        public async Task DeleteAsync(IssueEntity model)
        {
            await base.DeleteAsync(model);
        }

        public async Task<IEnumerable<IssueEntity>> GetAllAsync()
        {
            return await base.GetAllAsync();
        }

        public Task<IssueEntity> GetByIdAsync<Tid>(Tid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExists(string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangeAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(IssueEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
