using BookStore.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Categories;

internal class Category
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    #region Relationships

    private List<Book> _books = new();

    public IEnumerable<Book> Books => _books;

    #endregion
}
