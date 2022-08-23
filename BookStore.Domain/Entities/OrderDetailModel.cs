using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class OrderDetail : AuditableBaseEntity
{
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public decimal Qty { get; set; }
    public decimal Price { get; set; }

    #region ReltionShips
    public Book Book { get; set; }
    public Order Order { get; set; }
    #endregion

}
