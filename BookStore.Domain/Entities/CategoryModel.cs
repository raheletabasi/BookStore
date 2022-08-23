using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Category : AuditableBaseEntity
{
    public string Title { get; set; }

    #region Relationships

    private List<BookCategory> _bookCategories = new();

    public IEnumerable<BookCategory> BookCategories => _bookCategories;

    #endregion
}
