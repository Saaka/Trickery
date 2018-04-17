using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trickery.Model.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }

        public ICollection<GoogleUserMap> GoogleUserMaps { get; set; }
    }
}
