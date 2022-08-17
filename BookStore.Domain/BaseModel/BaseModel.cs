using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.BaseModel;

public class BaseModel
{
    public long Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateDate { get; set; } = DateTime.Now;
}
