using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class OrderDetailViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "سفارش")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid OrderId { get; set; }

    [Display(Name = "کتاب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid BookId { get; set; }

    [Display(Name = "تعداد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public decimal Qty { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public decimal Price { get; set; }
}

public enum ResultOrderDetail
{
    success,
    duplicate,
    notFound,
    Error
}
