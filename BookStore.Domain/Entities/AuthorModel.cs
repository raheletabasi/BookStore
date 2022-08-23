using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Author : AuditableBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    #region Relations

    private List<Book> _books = new();
    public IEnumerable<Book> Books => _books;

    #endregion
}
