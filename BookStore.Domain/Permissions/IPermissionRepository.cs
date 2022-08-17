using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Permissions;

public class IPermissionRepository
{
    public Guid Id { get; set; }
    public string Title { get; set; }
}
