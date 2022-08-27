using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class PermissionViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string Title { get; set; }

    [Display(Name = "والد")]
    public Guid? PermissionId { get; set; }
}

public enum ResultPermission
{
    success,
    duplicate,
    notFound,
    Error
}