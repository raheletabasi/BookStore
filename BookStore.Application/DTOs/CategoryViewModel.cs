using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class CategoryViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Title { get; set; }
}

public enum ResultCategory
{
    success,
    duplicate,
    notFound,
    Error
}
