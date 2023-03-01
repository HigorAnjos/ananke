using Ananke.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Application.IServices
{
    public interface IStudentServices
    {
        public Task<string> Login(string Email, string Password);
        public Task<bool> Register(Student ToCreate);
        public Task<Student> GetStudent(Guid Id);
        public Task<Student> UpdateStudent(Student ToUpdate);
        public Task<bool> DeleteStudent(Guid Id);
        public Task<IEnumerable<Student>> GetAllStudents();
    }
}
