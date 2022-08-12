using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
    public class GroupUser
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupsId { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UsersId { get; set; }
        public virtual User User { get; set; }

        public bool IsAdmin { get; set; }
    }
}
