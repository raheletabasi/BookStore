using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Books;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Authors { get; set; }
    public string Publisher { get; set; }
    public int Category { get; set; }
    public string Description { get; set; }
    public decimal price { get; set; }
    public string SearchExperssion { get; set; }
}
