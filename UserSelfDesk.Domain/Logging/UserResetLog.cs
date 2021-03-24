using System;
using UserSelfDesk.Domain.Common;

namespace UserSelfDesk.Domain.Logging
{
    public class UserResetLog : BaseEntity<long>
    {

        public string UserAccount { get; set; }
        public string ResetRequestTime { get; set; }       
        public string IpAddress { get; set; }
        public string ResetType { get; set; }
        public string ResetReason { get; set; }
        public DateTime ResetTime { get; set; }
    }
}
