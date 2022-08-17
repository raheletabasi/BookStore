using BookStore.Domain.BaseEntities;
using BookStore.Domain.Roles;
using BookStore.Domain.Permissions;

namespace BookStore.Domain.RolePermissions;

public class RolePermission : BaseEntity
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }

    #region Relations

    public Role Role { get; set; }
    public Permission Permission { get; set; }

    #endregion
}
