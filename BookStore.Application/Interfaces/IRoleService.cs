using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IRoleService
{
    Task<ResultRole> AddRole(RoleViewModel roleViewModel);
    Task<ResultRole> DeleteRole(Guid id);
    Task<ResultRole> UpdateRole(RoleViewModel roleViewModel);
    Task<IEnumerable<Role>> GetAllRoles();
    Task<Role> GetRolebyId(Guid roleId);
}
