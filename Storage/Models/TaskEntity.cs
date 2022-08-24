using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        [ForeignKey(nameof(Group))]
        public int GroupId { get; set; }
        public virtual Group Group { get; set; }

        public virtual ICollection<TaskRow> TaskRows { get; set; }
    }
}
