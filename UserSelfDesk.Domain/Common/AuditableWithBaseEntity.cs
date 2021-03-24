using System;
using System.Collections.Generic;
using System.Text;

namespace UserSelfDesk.Domain.Common
{
    public abstract class AuditableWithBaseEntity<T> : BaseEntity<T>, IAuditableEntity
    {
        public bool IsDeleted { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }        
        public long Author { get; set; }
        public DateTime? Modified { get; set; }
        public long Editor { get; set; }
    }
}
