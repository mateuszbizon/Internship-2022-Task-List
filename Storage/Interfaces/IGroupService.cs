using Helpers.Requests;

namespace Storage.Interfaces
{
    public interface IGroupService
    {
        Task<(bool success, string message)> CreateGroup(GroupRequest group);
    }
}
