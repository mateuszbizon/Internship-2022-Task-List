using Helpers.Requests;
using Storage.Models;

namespace Storage.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByName(LoginRequest loginDto);
    }
}
