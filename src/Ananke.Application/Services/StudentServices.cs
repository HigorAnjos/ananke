using Ananke.Application.IServices;
using Ananke.Domain.Entities;
using Ananke.Domain.Repository;

namespace Ananke.Application.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IStudentRepository _studentRepository;

        public StudentServices(ITokenGenerator tokenGenerator, IStudentRepository studentRepository)
        {
            _tokenGenerator = tokenGenerator;
            _studentRepository = studentRepository;
        }

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

        public Task<string> Login(string email, string password)
        {
            //var studentFound = await _studentRepository.GetStudentByEmail(email);

            //if (studentFound == null || studentFound.Password != password)
            //{
            //    throw new BadHttpRequestException("E-mail e/ou senha inválidos!");
            //}

            var student = new Student();
            student.Password= "123456789";
            return Task.FromResult(_tokenGenerator.GetToken(student));
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
