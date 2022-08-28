using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class UserRoleViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid UserId { get; set; }

    [Display(Name = "نقش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid RoleId { get; set; }
}

public enum ResultUserRole
{
    success,
    duplicate,
    notFound,
    Error
}