using BookStore.Domain.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class EditUserProfileViewModel
{
    [Display(Name = "نام")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string FirstName { get; set; }

    [Display(Name = "نام خانوادگی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string LastName { get; set; }

    [Display(Name = "جنسیت")]
    public UserGender Gender { get; set; }

    [Display(Name = "موبایل")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Mobile { get; set; }

    [Display(Name = "تاریخ تولد")]
    public DateTime Birthdate { get; set; }

    [Display(Name = "استان")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public int State { get; set; }

    [Display(Name = "شهر")]
    [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public int City { get; set; }

    [Display(Name = "آدرس")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Address { get; set; }

    [Display(Name = "کد پستی")]
    [MaxLength(12, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string PostalCode { get; set; }
}

public enum ResultEditUserProfile
{ 
    success,
    notFound,
    error
}
