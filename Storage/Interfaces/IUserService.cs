using Helpers.Requests;

namespace Storage.Interfaces
{
    public interface IUserService
    {
        Task<(bool success, string message)> CreateUser(RegistrationRequest request);
        Task<(bool success, string message)> Login(UserRequest request);
    }
}
