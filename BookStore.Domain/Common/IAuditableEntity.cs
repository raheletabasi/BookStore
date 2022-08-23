using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Common
{
    public interface IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public Guid CreatedUserId { get; set; }
        public Guid ModifiedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
