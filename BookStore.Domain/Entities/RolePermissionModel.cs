using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class RolePermission : AuditableBaseEntity
{
    public Guid RoleId { get; set; }
    public Guid PermissionId { get; set; }

    #region Relations

    public Role Role { get; set; }
    public Permission Permission { get; set; }

    #endregion
}
