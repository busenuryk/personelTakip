using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId{get; set;}

    }
}
