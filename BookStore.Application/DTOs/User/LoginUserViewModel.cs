using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs.User;

public class LoginUserViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "نام کاربری")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string UserName { get; set; }

    [Display(Name = "ایمیل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Email { get; set; }

    [Display(Name = "رمزعبور")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Password { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }
}

public enum ResultLoginUser
{
    success,
    notFound,
    inactive,
    block,
    Error
}
