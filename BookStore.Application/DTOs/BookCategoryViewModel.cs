using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class BookCategoryViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "کتاب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid BookId { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public Guid CategoryId { get; set; }
}

public enum ResultBookCategory
{
    success,
    duplicate,
    notFound,
    Error
}


