using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class Order : AuditableBaseEntity
{
    public Guid UserId { get; set; }
    public decimal OrderSum { get; set; }
    public bool IsFinaly { get; set; }

    #region Relations

    private List<OrderDetail> _orderDetails = new();

    public User User { get; set; }
    public IEnumerable<OrderDetail> OrderDetails => _orderDetails;

    #endregion
}
