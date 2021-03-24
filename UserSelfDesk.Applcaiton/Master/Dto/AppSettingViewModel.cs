using System;
using System.Collections.Generic;
using System.Text;

namespace UserSelfDesk.Applcaiton.Master.Dto
{
   public class AppSettingViewModel
    {
        public long id { get; set; }
        public string referenceKey { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public bool isDeleted { get; set; }
        public bool active { get; set; }
        public DateTime created { get; set; }
        public DateTime modified { get; set; }
        public string author { get; set; }
        public string editor { get; set; }
    }
}
