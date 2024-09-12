using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public abstract record UserDtoForManipulation
    {
        public String Name { get; init; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; init; }
        [Required(ErrorMessage = "Password is required")]
        [MinLength(5, ErrorMessage ="Password must consist of at least 5 characters")]
        public String Password { get; init; }
    }
}
