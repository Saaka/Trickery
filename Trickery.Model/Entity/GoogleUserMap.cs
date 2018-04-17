using System.ComponentModel.DataAnnotations;

namespace Trickery.Model.Entity
{
    public class GoogleUserMap
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string GoogleId { get; set; }

        public virtual User User { get; set; }
    }
}
