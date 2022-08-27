using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class OrderViewModel
{
    [Display(Name = "سفارش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid OrderId { get; set; }

    [Display(Name = "کاربر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid UserId { get; set; }
}

public enum ResultOrder
{ 
    success,
    notFound,
    Error
}
