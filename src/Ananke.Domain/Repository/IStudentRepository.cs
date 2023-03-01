using Ananke.Domain.Entities;


namespace Ananke.Domain.Repository
{
    public interface IStudentRepository
    {
        public Task<Student> GetStudentByEmail(string email);
        public Task<Student> GetStudentById(Guid id);
        public Task<Student> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(Guid id);
        public Task<bool> CreateStudent(Student student);
        public Task<List<Student>> GetAllStudents();
    }
}
