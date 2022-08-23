using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class UserRole : AuditableBaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    #region Relations
    public User User { get; set; }
    public Role Role { get; set; }
    #endregion
}
