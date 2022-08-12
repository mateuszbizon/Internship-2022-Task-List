using Helpers.Requests;
using Storage.Data;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context): base(context)
        {

        }

        public User GetUserByName(LoginRequest loginDto)
        {
            return _context.Users
                        .Where( u => u.Email == loginDto.Email && u.Password == loginDto.Password)
                        .FirstOrDefault();
        }

        
    }
}
