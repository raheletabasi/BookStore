using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Generic;

public interface IGenericRepositry
{
    public Task AddAsync();
    public Task UpdaeAsync();
    public Task DeleteAsync(Guid id);
    public Task GetAllAsync();
    public Task GetByIdAsync(Guid id);
    public Task SoftDelete(Guid id);
}
