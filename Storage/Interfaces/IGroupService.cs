using Helpers.Requests;

namespace Storage.Interfaces
{
    public interface IGroupService
    {
        Task CreateGroup(GroupRequest group);
    }
}
