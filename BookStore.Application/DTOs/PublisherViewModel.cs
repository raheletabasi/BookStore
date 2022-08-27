using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class PublisherViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public  string Title { get; set; }

    [Display(Name = "آدرس")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Address { get; set; }
}

public enum ResultPublisher
{
    success,
    duplicate,
    notFound,
    Error
}
