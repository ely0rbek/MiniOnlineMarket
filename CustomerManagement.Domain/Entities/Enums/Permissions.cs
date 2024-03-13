using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Domain.Entities.Enums
{
    public enum Permissions
    {
        GetAllPersons=1,
        GetPersonById=2, 
        GetPersonByName=3,
        UpdatePersonAccount=4,
        DeletePersonById=5,

        CreateProduct=6,
        GetAllProduct =7,
        GetProductById=8,
        GetProductByName=9,
        UpdateProductById=10,
        DeleteProductById=11,

        CreateAdmin=12,
        GetAllAdmins=13,
        GetAdminByAdminId=14,
        UpdateAdminByAdminId=15,
        DeleteAdminByAdminId=16,

        CreateRolePermission=17,
        GetAllRolePermissions=18,
        GetRolePermissionById=19,
        UpdateRolePermissionById=20,
        DeleteRolePermissionById=21,

        CreateOrder=22,
        GetAllOrders=23,
        GetOrderByName=24,
        UpdateOrderById=25,
        DeleteOrderById=26,
    }
}
