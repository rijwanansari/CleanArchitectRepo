using UserSelfDesk.Domain.Common;

namespace UserSelfDesk.Domain.Master
{
    public class ReferenceMaster : BaseEntity<int>
    {
        /// <summary>
        /// Gets or sets the title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the code
        /// </summary>
        public string RefCode { get; set; }
    }
}
