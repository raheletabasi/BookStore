using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Users;

public interface IUserRepository
{
    public Task IsDuplicate(string userName, string email);
    public Task IsDuplicate(Guid Id, string userName, string email);
}
