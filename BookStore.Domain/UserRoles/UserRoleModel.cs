using BookStore.Domain.BaseEntities;
using BookStore.Domain.Roles;
using BookStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.UserRoles;

public class UserRole : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    #region Relations
    public User User { get; set; }
    public Role Role { get; set; }
    #endregion
}
