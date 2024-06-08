using System.Threading.Tasks;
using TFGDevopsApp.Data;

namespace TFGDevopsApp.Interfaces
{
    public interface IUserRepository
    {

        Task<ApplicationUser> RegisterUser(string  email, string password);

        Task<ApplicationUser> GetUserById(string userId);

        Task<ApplicationUser> GetUserByName(string userName);

        Task<List<ApplicationUser>> GetAllUsers();
        Task<bool> ValidateLog(string userName, string password);

        Task UpdateUser(ApplicationUser user);

        Task DeleteUser(string userId);
        Task<bool> ValidateUser(string nombre, string password);
    }
}
