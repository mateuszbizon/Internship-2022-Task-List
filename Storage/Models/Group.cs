using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<GroupUser> GroupsUsers { get; set; }
        public virtual ICollection<TaskEntity> TaskLists { get; set; }
    }
}
