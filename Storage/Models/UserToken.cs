using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Storage.Models
{
    public abstract class UserToken
    {
        [Key]
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
