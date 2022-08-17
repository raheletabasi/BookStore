using BookStore.Domain.BaseEntities;
using BookStore.Domain.Books;
using BookStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.OrderDetails;

public class OrderDetail : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid BookId { get; set; }
    public decimal Qty { get; set; }
    public decimal Price { get; set; }

    #region ReltionShips
    public Book Book { get; set; }
    #endregion

}
