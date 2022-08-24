using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class ChangePasswordViewModel
{
    [Display(Name = "رمزعبور فعلی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string CurrentPassword { get; set; }

    [Display(Name = "رمزعبور جدید")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string NewPassword { get; set; }

    [Display(Name = "تکرار رمزعبور جدید")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    [Compare("Password", ErrorMessage = "کلمه ی عبور با هم مغایرت دارند")]
    public string ReNewPassword { get; set; }
}

public enum ResultChangePassword
{ 
    success,
    equalPassword,
    notFound,
    error
}
