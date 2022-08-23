using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Common
{
    public abstract class AuditableBaseEntity : BaseEntity, IAuditableEntity
    {
        public bool IsDeleted { get; set; } = false;
        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; }
    }
}
