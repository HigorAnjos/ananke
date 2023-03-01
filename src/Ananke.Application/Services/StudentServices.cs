using Ananke.Application.IServices;
using Ananke.Domain.Entities;

namespace Ananke.Application.Services
{
    public class StudentServices : IStudentServices
    {
        public Task<bool> DeleteStudent(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetStudent(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Login(string Email, string Password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(Student ToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<Student> UpdateStudent(Student ToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
