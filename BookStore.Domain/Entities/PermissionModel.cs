using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Permission : AuditableBaseEntity
{
    public string Title { get; set; }
    public long? ParentId { get; set; }

    #region Relations

    private List<Permission> _permission = new();
    private List<RolePermission> _rolePermissions = new();

    public IEnumerable<Permission> Permissions => _permission;
    public IEnumerable<RolePermission> RolePermissions => _rolePermissions;

    #endregion
}
