namespace TFGDevopsApp1.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Task<bool> LoginUser(string username, string password);
    }
}
