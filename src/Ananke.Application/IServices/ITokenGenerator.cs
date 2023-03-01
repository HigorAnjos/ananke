using Ananke.Domain.Entities;


namespace Ananke.Application.IServices
{
    public interface ITokenGenerator
    {
        public string GetToken(Student Student);
    }
}
