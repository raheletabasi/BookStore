using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Books;

public interface IBookRepository
{
    public Task IsDuplicate(string name);
    public Task IsDuplicate(Guid Id, string name);
}
