using BookStore.Domain.Common;
using BookStore.Domain.Entity;

namespace BookStore.Domain.Entities;

public class Publisher : AuditableBaseEntity
{
    public string Title { get; set; }
    public string? Address { get; set; }

    #region Relations

    private List<Book> _books = new();
    public IEnumerable<Book> Books => _books;

    #endregion
}
