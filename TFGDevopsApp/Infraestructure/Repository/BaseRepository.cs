using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TFGDevopsApp.Data;

namespace TFGDevopsApp.Infraestructure.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> 
        where T : class
    {
        protected readonly ApplicationDbContext _context;

        protected BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                                 .FindAsync(id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            if (await _context.SaveChangesAsync() > 0)
                return entity;
            else
                return null;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public bool IsExistsAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Any(predicate);
        }

        public Task<bool> SaveChangeAsync()
        {
            return Task.FromResult(_context.SaveChanges() > 0);
        }

        public async Task<T> DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            await _context.SaveChangesAsync();
            return model;
        }
    }
}
