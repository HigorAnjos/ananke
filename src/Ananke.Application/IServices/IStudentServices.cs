using Ananke.Domain.Entities;


namespace Ananke.Application.IServices
{
    public interface IStudentServices
    {
        public Task<string> Login(string email, string password);
        public Task<bool> Register(Student student);
        public Task<Student> GetStudent(Guid id);
        public Task<Student> UpdateStudent(Student student);
        public Task<bool> DeleteStudent(Guid id);
        public Task<IEnumerable<Student>> GetAllStudents();
    }
}
