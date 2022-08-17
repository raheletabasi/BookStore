using BookStore.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.BaseEntities;

public class BaseEntity
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedUserId { get; set; }
    public Guid ModifiedUserId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime ModifiedDate { get; set; }

    #region Relations

    public User CreatedUser { get; set; }
    public User ModifiedUser { get; set; }

    #endregion
}
