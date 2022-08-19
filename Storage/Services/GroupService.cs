using Helpers.Requests;
using Storage.Interfaces;
using Storage.Models;

namespace Storage.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        public async Task CreateGroup(GroupRequest request)
        {
            var group = new Group
            {
                Name = request.Name,
            };
            /*
            group.GroupsUsers.Add(new()
            {
                //UsersId = ,
                IsAdmin = true,
            });

            */
            await _groupRepository.CreateAsync(group);
        }
    }
}
