using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TFGDevopsApp.Data;
using TFGDevopsApp.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp.Infraestructure.Repository
{
    public class IssueTrackingRepository : BaseRepository<IssueTracking>, IIssueTrackingRepository
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public IssueTrackingRepository(ApplicationDbContext context,
                                       ILogger<IssueTrackingRepository> logger,
                                       IMapper mapper)
            :base(context)
        {
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<IssueTracking>> GetAllAsync()
        {
            return await _context.IssueTrackings.ToListAsync();
        }

        public async Task<IssueTracking> GetByIdAsync(int id)
        {
            return await _context.IssueTrackings
                                 .FindAsync(id);
        }

        public async Task<IssueTracking> CreateAsync(IssueTracking entity)
        {
            await _context.IssueTrackings.AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                return null;
        }

        public async Task<IssueTracking> UpdateAsync(IssueTracking entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool IsExistsAsync(Expression<Func<IssueTracking, bool>> predicate)
        {
            return _context.IssueTrackings.Any(predicate);
        }

        public async Task<bool> SaveChangeAsync()
        {
            var response = await _context.SaveChangesAsync();
            return response > 0;
        }

        public async Task<IssueTracking> DeleteAsync(IssueTracking model)
        {
            _context.IssueTrackings.Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }

    }
}
