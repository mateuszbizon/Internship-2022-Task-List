using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Storage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<EmailConfirmation> EmailConfirmations { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<PasswordReset> PasswordResets { get; set; }

        public virtual DbSet<TaskRow> TaskRows { get; set; }

        public virtual DbSet<TaskEntity> TaskLists { get; set; }
        public virtual DbSet<GroupUser> GroupUser { get; set; }
    }

}
