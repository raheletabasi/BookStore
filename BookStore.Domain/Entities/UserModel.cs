using BookStore.Domain.Common;

namespace BookStore.Domain.Entity;

public class User : AuditableBaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserGender Gender { get; set; }
    public UserStatus Status { get; set; }
    public DateTime Birthdate { get; set; }
    public int State { get; set; }
    public int City { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public string SearchExperssion { get; set; }

    #region Relations

    private List<UserRole> _userRoles = new();
    public IEnumerable<UserRole> UserRoles => _userRoles;

    #endregion    
}

#region Enums
public enum UserGender
{
    Male,
    Femail,
    Unknown
}

public enum UserStatus
{
    Active,
    Inactive,
    Block
}
#endregion