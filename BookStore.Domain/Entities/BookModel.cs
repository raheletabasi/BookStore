using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Book : AuditableBaseEntity
{
    public string Name { get; set; }
    public Guid AuthorId { get; set; }
    public string Publisher { get; set; }
    public string Description { get; set; }
    public decimal price { get; set; }
    public bool IsActive { get; set; }
    public string SearchExperssion { get; set; }

    #region Relations

    private List<OrderDetail> _orderDetails = new();
    private List<BookCategory> _bookCategories = new();

    public IEnumerable<OrderDetail> OrderDetails => _orderDetails;
    public IEnumerable<BookCategory> BookCategories => _bookCategories;

    public Author Author { get; set; }

    #endregion
}
