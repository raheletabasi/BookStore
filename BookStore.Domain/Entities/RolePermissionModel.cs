using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class RolePermission : AuditableBaseEntity
{
    public long RoleId { get; set; }
    public long PermissionId { get; set; }

    #region Relations

    public Role Role { get; set; }
    public Permission Permission { get; set; }

    #endregion
}
