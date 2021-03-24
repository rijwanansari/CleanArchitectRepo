using UserSelfDesk.Domain.Common;

namespace UserSelfDesk.Domain.Master
{
   public class AppSetting : AuditableWithBaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string ReferenceKey { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        public string Description { get; set; }
        public string Type { get; set; }
    }
}
