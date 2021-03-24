using System;

namespace UserSelfDesk.Domain.Common
{
    public interface IAuditableEntity
    {
        bool IsDeleted { get; set; }
        bool Active { get; set; }
        DateTime Created { get; set; }
        long Author { get; set; }
        DateTime? Modified { get; set; }
        long Editor { get; set; }      
    }
}
