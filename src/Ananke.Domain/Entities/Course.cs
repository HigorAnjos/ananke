using Ananke.Domain.Entities.Base;
using Ananke.Domain.Enums;
using Ananke.Domain.ValueObjects;

namespace Ananke.Domain.Entities
{
    public class Course : EntityBase
    {
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int Credits { get; set; }
        public List<SchedulesWeek> Schedules { get; set; }
        public int Semester { get; set; }
        public List<Assessments> Exams { get; private set; }
        public int TotalNumberOfClassesScheduled { get; set; }
        public int TotalNumberOfAbsences { get; set; }
        public DateTime AbsencesDate { get; set; }
        public StatusCorse Status { get; set; }
        public double AI { get; set; }
        public List<OtherWorks> Works { get; set; }
        public double Media { get; set; } = 6;
        public Course(string name, string teacher, int credits, List<SchedulesWeek> schedules, int semester, int totalNumberOfClassesScheduled, int totalNumberOfAbsences, DateTime absencesDate, StatusCorse status, float aI, List<OtherWorks> works, float media)
        {
            Name = name;
            Teacher = teacher;
            Credits = credits;
            Schedules = schedules;
            Semester = semester;
            Exams = new List<Assessments>()
            {
                new Assessments(ExamsSemester.FirstExam),
                new Assessments(ExamsSemester.SecondExam),
                new Assessments(ExamsSemester.ThirdExam),
                new Assessments(ExamsSemester.QuarterExam)
            };
            TotalNumberOfClassesScheduled = totalNumberOfClassesScheduled;
            TotalNumberOfAbsences = totalNumberOfAbsences;
            AbsencesDate = absencesDate;
            Status = status;
            AI = aI;
            Works = works;
            Media = media;
        }
        public Course() 
        {
            Name= string.Empty;
            Teacher= string.Empty;
            Schedules = new List<SchedulesWeek>();
            Exams = new List<Assessments>()
            {
                new Assessments(ExamsSemester.FirstExam),
                new Assessments(ExamsSemester.SecondExam),
                new Assessments(ExamsSemester.ThirdExam),
                new Assessments(ExamsSemester.QuarterExam)
            };
            Works = new List<OtherWorks>();
            SetId();
        }

        private double Truncate (double value, int decimalPlaces)
        {
            double truncatedValue = Math.Truncate(value * Math.Pow(10, decimalPlaces)) / Math.Pow(10, decimalPlaces);
            return truncatedValue;
        }

        private double CalculateEvidenceMediaAsync(double NotaA, double NotaB)
        {
            return (NotaA * 3.35 + NotaB * 3.35) / 6.7; 
        }

        public double CalculateSemesterAverage()
        {
            var n1 = CalculateEvidenceMediaAsync(Exams[0].Note, Exams[1].Note);
            var n2 = CalculateEvidenceMediaAsync(Exams[2].Note, Exams[3].Note);
            var media = n1 * 0.4 + n2 * 0.5;
            
            return Truncate(media, 2);
        }

        public void SetExamNotes(ExamsSemester name, double note)
        {
            if (Exams[0].Name == name)
            {
                Exams[0].Note = note;
                Exams[0].IsOficialNote = true;
            }
            if (Exams[1].Name == name)
            {
                Exams[1].Note = note;
                Exams[1].IsOficialNote = true;
            }
            if (Exams[2].Name == name)
            {
                Exams[2].Note = note;
                Exams[2].IsOficialNote = true;
            }
            if (Exams[3].Name == name)
            {
                Exams[3].Note = note;
                Exams[3].IsOficialNote = true;
            }

            UpdateUnOfficialNotes();
        }

        public void UpdateUnOfficialNotes()
        {
            double diff = 0.0;
            double totalNotaNaoOficial = 0.0;
            int countTotalNotasNaoOficial = 0;
            foreach (var exam in Exams)
            {
                diff += 6.7 - exam.Note;
                if (!exam.IsOficialNote)
                {
                    totalNotaNaoOficial += exam.Note;
                    countTotalNotasNaoOficial++;
                }
            }

            if (countTotalNotasNaoOficial <= 0)
            {
                throw new Exception("Todas as notas foram inseridas");
            }

            var novaNotaMedia = (totalNotaNaoOficial + diff) / countTotalNotasNaoOficial;
            var novaNotaMediaTruncate = Truncate(novaNotaMedia, 2);

            foreach (var exam in Exams)
            {
                if (!exam.IsOficialNote)
                {
                    exam.Note = novaNotaMediaTruncate;
                }
            }
        }

    }
}
