using Ananke.Domain.Entities;
using Ananke.Domain.Enums;
using FluentAssertions;

namespace Unit.Test.Domain.Entities
{
    public class CourseUnitTest
    {
        [Theory]
        [InlineData(6.03)]
        public void Should_Calculate_Media_Projection_Correctly_Default(double mediaExpected)
        {
            var course = new Course();
            var mediaSemestre = course.CalculateSemesterAverage();
            mediaSemestre.Should().Be(mediaExpected);
        }
        [Theory]
        [InlineData(5, 7.26, 6.08)]
        [InlineData(4.5, 7.43, 6.10)]
        public void WenSetFirtsProve_ShouldCalculateMediaProjection_Correctly(double p1, double otherP, double mediaExpected)
        {
            var course = new Course();
            course.SetExamNotes(ExamsSemester.FirstExam, p1);

            course.Exams[1].Note.Should().Be(otherP);
            course.Exams[2].Note.Should().Be(otherP);
            course.Exams[3].Note.Should().Be(otherP);

            var mediaSemestre = course.CalculateSemesterAverage();
            mediaSemestre.Should().Be(mediaExpected);
        }
    }
}
