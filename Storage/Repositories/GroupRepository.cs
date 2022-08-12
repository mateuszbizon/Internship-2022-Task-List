using Storage.Data;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {

        }

        public Group GetGroupByName(string GroupName)
        {
            return _context.Groups
                .Where(g => g.Name == GroupName)
                .FirstOrDefault();
        }
    }
}
