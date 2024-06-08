namespace TFGDevopsApp.Interfaces
{
    public interface ITareaRepository
    {
        Task Add(object a);
        Task Delete(object a);
        Task Update(object a);
    }
}
