using BookStore.Domain.BaseEntities;
using BookStore.Domain.OrderDetails;
using BookStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Orders;

public class OrderModel : BaseEntity
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
