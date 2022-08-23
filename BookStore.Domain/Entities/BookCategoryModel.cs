using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class BookCategory : AuditableBaseEntity
{
    public Guid BookId { get; set; }
    public Guid CategoryId { get; set; }

    #region Relation

    public Book Book { get; set; }
    public Category Category { get; set; }

    #endregion
}
