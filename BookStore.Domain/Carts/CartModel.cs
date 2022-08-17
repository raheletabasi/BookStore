using BookStore.Domain.Books;
using BookStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Carts;

public class Cart
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public Guid BookId { get; set; }
    public decimal Qty { get; set; }
    public decimal Price { get; set; }
    public decimal Total { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ModifiedDate { get; set; }

    #region ReltionShips
    public User User { get; set; }
    public Book Book { get; set; }
    #endregion

}
