using Ananke.Domain.Enums;

namespace Ananke.Domain.ValueObjects
{
    public class Assessments
    {
        public ExamsSemester Name { get; set; }
        public double Note { get; set; }
        public DateTime Data { get; set; }
        public bool IsOficialNote { get; set; }

        public Assessments(ExamsSemester name)
        {
            Name = name;
            Note = 6.7;
            IsOficialNote = false;
        }
    }
}
