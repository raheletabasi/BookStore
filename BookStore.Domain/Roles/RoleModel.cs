using BookStore.Domain.BaseEntities;
using BookStore.Domain.RolePermissions;
using BookStore.Domain.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Roles;

public class Role : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }

    #region Relations

    private List<UserRole> _userRoles = new();
    private List<RolePermission> _rolePermission = new();

    public IEnumerable<UserRole> UserRoles => _userRoles;
    public IEnumerable<RolePermission> RolePermissions => _rolePermission;

    #endregion
}
