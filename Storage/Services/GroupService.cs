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
        public async Task CreateGroup(GroupRequest group)
        {
            var groupDto = new Group
            {
                Name = group.Name,
            };
            /*
            groupDto.GroupsUsers.Add(new()
            {
                //UsersId = ,
                IsAdmin = true,
            });

            */
            await _groupRepository.CreateAsync(groupDto);
        }
    }
}
