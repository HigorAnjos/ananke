using Ananke.Domain.Entities;


namespace Ananke.Domain.Repository
{
    public interface IScrapingRepository
    {
        Task<List<Course>> GetDataPucAsync();
    }
}
