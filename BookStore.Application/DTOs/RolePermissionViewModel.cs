using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class RolePermissionViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid RoleId { get; set; }

    [Display(Name = "دسترسی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid PermissionId { get; set; }
}

public enum ResultRolePermission
{
    success,
    duplicate,
    notFound,
    Error
}
