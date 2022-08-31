using Helpers.Requests;
using Storage.Data;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public User GetUserByEmail(string email)
        {
            return _context.Users
                        .FirstOrDefault(u => u.Email == email);
        }
    }
}
