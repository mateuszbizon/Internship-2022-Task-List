using Storage.Models;

namespace Storage.Interfaces
{
    public interface IGroupRepository : IBaseRepository<Group>
    {
        Group GetGroupByName(string GroupName);
    }
}
