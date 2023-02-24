using Ananke.Domain.Entities;
using Ananke.Domain.Repository;

namespace Ananke.Infra.Data
{
    public class ScrapingRepository : IScrapingRepository
    {
        public Task<List<Course>> GetCoursesAsync()
        {
            var mock = new List<Course>()
            {
                new Course(),
                new Course()
            };

            mock[0].Name= "A";
            mock[1].SetNoteExam(Domain.Enums.ExamsSemester.FirstExam, 5);
            mock[1].Name = "B";

            return Task.FromResult(mock);
        }
    }
}
