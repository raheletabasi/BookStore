using BookStore.Domain.BaseEntities;
using BookStore.Domain.BookCategories;
using BookStore.Domain.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Categories;

public class Category : BaseEntity
{
    public string Title { get; set; }

    #region Relationships

    private List<BookCategory> _bookCategories = new();

    public IEnumerable<BookCategory> BookCategories => _bookCategories;

    #endregion
}
