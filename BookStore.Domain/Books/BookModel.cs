using BookStore.Domain.BaseEntities;
using BookStore.Domain.BookCategories;
using BookStore.Domain.Categories;
using BookStore.Domain.OrderDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Books;

public class Book : BaseEntity
{
    
    public string Name { get; set; }
    public string Authors { get; set; }
    public string Publisher { get; set; }
    public int Category { get; set; }
    public string Description { get; set; }
    public decimal price { get; set; }
    public bool IsActive { get; set; }
    public string SearchExperssion { get; set; }

    #region Relations

    private List<OrderDetail> _orderDetails = new();
    private List<BookCategory> _bookCategories = new();


    public IEnumerable<OrderDetail> OrderDetails => _orderDetails;
    public IEnumerable<BookCategory> BookCategories => _bookCategories;

    #endregion
}
