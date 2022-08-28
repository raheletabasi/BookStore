using BookStore.Application.DTOs;
using BookStore.Domain.Entity;

namespace BookStore.Application.Interfaces;

public interface IUserRoleService
{
    Task<ResultUserRole> AddUserRole(UserRoleViewModel userRoleViewModel);
    Task<ResultUserRole> DeleteUserRole(Guid id);
    Task<ResultUserRole> UpdateUserRole(UserRoleViewModel userRoleViewModel);
    Task<IEnumerable<UserRole>> GetAllUserRole();
    Task<UserRole> GetRolesbyUserId(Guid userId);
}
