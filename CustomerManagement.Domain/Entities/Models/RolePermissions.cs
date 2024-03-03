namespace CustomerManagement.Domain.Entities.Models
{
    public class RolePermissions
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<int> Permissions { get; set; }
    }
}
