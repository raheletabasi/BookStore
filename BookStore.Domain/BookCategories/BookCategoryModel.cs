using BookStore.Domain.BaseEntities;
using BookStore.Domain.Books;
using BookStore.Domain.Categories;

namespace BookStore.Domain.BookCategories;

public class BookCategory : BaseEntity
{
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }

    #region Relation

    public Book Book { get; set; }
    public Category Category { get; set; }

    #endregion
}
