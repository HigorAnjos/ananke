using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Domain.Enums
{
    public enum ClassTime
    {
        [Description("07:15 - 08:45")]
        FirstClassSchedule = 0,

        [Description("09:00 - 10:30")]
        SecondClassSchedule = 1,

        [Description("10:45 - 12:15")]
        ThirdClassSchedule = 2,
    }
}
