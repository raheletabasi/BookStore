using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Users;

public class User
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthdate { get; set; }
    public int State { get; set; }
    public int City { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string SearchExperssion { get; set; }

    #region Relationship

    #endregion
}
