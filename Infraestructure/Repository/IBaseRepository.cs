using System.Linq.Expressions;
using TFGDevopsApp1.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp1.Infraestructure.Repository
{
    public interface IBaseRepository<T>
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        bool IsExistsAsync(Expression<Func<T, bool>> predicate);
        Task<bool> SaveChangeAsync();
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T model);
    }
}