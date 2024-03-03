using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CustomerManagement.Domain.Entities.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int UserRole { get; set; } = 1;

        [EmailAddress]
        public required string Email { get; set; }

        [MinLength(6)]
        public required string Password { get; set; }
        public string PicturePath { get; set; }
        public List<int> Permissions { get; set; }
    }
}
