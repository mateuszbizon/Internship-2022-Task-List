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
        public async Task<(bool success, string message)> CreateGroup(GroupRequest request)
        {
            var existingGroup = _groupRepository.GetGroupByName(request.Name);

            if (existingGroup != null)
            {
                return (success: false, message: "Nazwa grupy jest juz zajeta");
            }

            var group = new Group
            {
                Name = request.Name
            };

            //group.GroupsUsers.Add(new()
            //{
            //    UsersId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
            //    IsAdmin = true,
            //});


            await _groupRepository.CreateAsync(group);
            return (success: true, message: "Stworzono grupę");
        }
    }
}
