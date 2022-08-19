using Helpers.Requests;
using Storage.Models;

namespace Storage.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetUserByEmail(string email);
    }
}
