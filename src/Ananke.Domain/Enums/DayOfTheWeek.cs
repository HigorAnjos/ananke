using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Domain.Enums
{
    public enum DayOfTheWeek
    {
        [Description("Domingo")]
        Sunday = 0,

        [Description("Segunda")]
        Monday = 1,

        [Description("Terca")]
        Tuesday = 2,

        [Description("Quarta")]
        Wednesday = 3,

        [Description("Quinta")]
        Thursday = 4,

        [Description("Sexta")]
        Friday = 5,

        [Description("sabado")]
        Saturday = 6,
    }
}
