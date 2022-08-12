using Helpers.Requests;

namespace Storage.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserRequest user);
        void Login(LoginRequest loginDto);
    }
}
