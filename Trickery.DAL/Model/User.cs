using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trickery.DAL.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public ICollection<GoogleUserMap> GoogleUserMaps { get; set; }
    }
}
