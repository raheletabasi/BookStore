using System.ComponentModel.DataAnnotations;

namespace BookStore.Application.DTOs;

public class BookViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "نام کتاب")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string Name { get; set; }

    [Display(Name = "نویسنده")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public Guid AuthorId { get; set; }

    [Display(Name = "ناشر")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public Guid PublisherId { get; set; }

    [Display(Name = "توضیحات")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public string? Description { get; set; }

    [Display(Name = "مبلغ")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
    public decimal Price { get; set; }

    [Display(Name = "وضعیت")]
    public bool IsActive { get; set; }

    public List<Guid> BookSelectedCategory { get; set; }
}

public enum ResultBook
{
    success,
    Duplicate,
    Error
}
