using BookStore.Domain.Common;
using BookStore.Domain.Entities;

namespace BookStore.Domain.Entity;

public class Book : AuditableBaseEntity
{
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public Guid PublisherId { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; }
    public string SearchExperssion { get; set; }

    #region Relations

    private List<OrderDetail> _orderDetails = new();
    private List<BookCategory> _bookCategories = new();

    public IEnumerable<OrderDetail> OrderDetails => _orderDetails;
    public IEnumerable<BookCategory> BookCategories => _bookCategories;

    public Author Author { get; set; }
    public Publisher Publisher { get; set; }

    #endregion
}
