using TFGDevopsApp.Data;

namespace TFGDevopsApp.Interfaces
{
    public interface IUserService
    {

        Task RegisterUser(string email, string password);

        Task<ApplicationUser> GetUserById(string userId);

        Task<ApplicationUser> GetUserByName(string userName);

        Task<List<ApplicationUser>> GetAllUsers();
        Task<bool> ValidateLogin(string userName, string password);

        Task UpdateUser(ApplicationUser user);

        Task DeleteUser(string userId);
        Task<bool> ValidateUser(string nombre, string password);
    }
}
