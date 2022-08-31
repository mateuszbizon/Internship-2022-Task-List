using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
    public class TaskRow
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? CompletedAt { get; set; }

        [ForeignKey(nameof(CompletedBy))]
        public Guid CompletedById { get; set; }
        public virtual User CompletedBy { get; set; }

        [ForeignKey(nameof(TaskList))]
        public int TaskListId { get; set; }
        public virtual TaskEntity TaskList { get; set; }

    }
}
