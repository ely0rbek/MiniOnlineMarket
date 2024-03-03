using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.Domain.Entities.DTOs
{
    public class PersonDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserRole { get; set; } = 1;

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }
    }
}
