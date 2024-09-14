
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObject
{
    public record UserDtoForUpdate : UserDtoForManipulation
    {
        [Required]
        public int Id { get; init; }
    }
}
