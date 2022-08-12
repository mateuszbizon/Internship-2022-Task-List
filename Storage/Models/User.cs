using System.ComponentModel.DataAnnotations;

namespace Storage.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsConfirmed { get; set; }

        public virtual ICollection<GroupUser> GroupUsers { get; set; }

        public virtual ICollection<TaskRow> TaskRows { get; set; }

        public virtual ICollection<EmailConfirmation> EmailConfirmations { get; set; }

        public virtual ICollection<PasswordReset> PasswordResets { get; set; }
    }
}
