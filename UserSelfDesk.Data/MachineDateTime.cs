using System;
using UserSelfDesk.CoreCommon.Helper;

namespace UserSelfDesk.Data
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;

        public int CurrentYear => DateTime.Now.Year;
    }
}
