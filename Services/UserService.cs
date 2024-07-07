using TFGDevopsApp1.Data;
using TFGDevopsApp1.Interfaces;

namespace TFGDevopsApp1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task RegisterUser(string email, string password)
        {
            await _userRepository.RegisterUser(email, password);
        }

        public async Task DeleteUser(string userId)
        {
            await _userRepository.DeleteUser(userId);
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<ApplicationUser> GetUserById(string userId)
        {
            return await _userRepository.GetUserById(userId);
        }

        public async Task<ApplicationUser> GetUserByName(string userName)
        {
            return await _userRepository.GetUserByName(userName);
        }

        public async Task UpdateUser(ApplicationUser user)
        {
            await _userRepository.UpdateUser(user);
        }

        public async Task<bool> ValidateLogin(string userName, string password)
        {
            return await _userRepository.ValidateLog(userName, password);
        }

        public async Task<bool> ValidateUser(string nombre, string password)
        {
            return await _userRepository.ValidateUser(nombre, password);
        }
    }
}
