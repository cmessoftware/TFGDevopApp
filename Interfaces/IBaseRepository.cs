namespace TFGDevopsApp1.Interfaces
{
    //Unit of Work Pattern
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById<Tid>(Tid id);
        Task<bool> IsExists(string key, string value);
        Task<bool> IsExistsForUpdate<Tid>(Tid id, string key, string value);
        Task<T> Create(T model);
        Task Update(T model);
        Task Delete(T model);
        Task SaveChangeAsync();
    }
}
