using Ananke.Domain.ValueObjects;

namespace Ananke.Domain.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public CredentialsPuc Credentials { get; set; }
    }
}
