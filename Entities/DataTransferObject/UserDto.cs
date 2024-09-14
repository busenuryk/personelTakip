

namespace Entities.DataTransferObject
{
    [Serializable]
    public record UserDto
    {
        public int UserId { get; init; }
        public string Name { get; init; }
        public string LastName { get; set; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string RoleName { get; set; }
    }

    
}
