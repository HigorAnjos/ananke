using Ananke.Domain.Enums;
using Ananke.Domain.ValueObjects.Base;

namespace Ananke.Domain.ValueObjects
{
    public partial class SchedulesWeek : ValueObjectBase<SchedulesWeek>
    {
        public DayOfTheWeek[] Week { get; private set; }

        public ClassTime Time { get; private set; }

        public SchedulesWeek(ClassTime time, DayOfTheWeek[] week)
        {
            Week = week;
            Time = time;
        }

        protected override bool EqualsCore(SchedulesWeek other)
        {
            return Week == other.Week && Time == other.Time;
        }

        protected override decimal GetHashCodeCore()
        {
            decimal hashCode = (Week.GetHashCode() + Time.GetHashCode()).GetHashCode();
            return hashCode;
        }
    }
}
