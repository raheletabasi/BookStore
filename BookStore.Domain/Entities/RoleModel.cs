using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Role : AuditableBaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }

    #region Relations

    private List<UserRole> _userRoles = new();
    private List<RolePermission> _rolePermission = new();

    public IEnumerable<UserRole> UserRoles => _userRoles;
    public IEnumerable<RolePermission> RolePermissions => _rolePermission;

    #endregion
}
