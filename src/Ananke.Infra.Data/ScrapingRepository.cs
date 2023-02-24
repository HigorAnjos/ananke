using Ananke.Domain.Entities;
using Ananke.Domain.Repository;

namespace Ananke.Infra.Data
{
    public class ScrapingRepository : IScrapingRepository
    {
        public Task<List<Course>> GetDataPucAsync()
        {
            throw new NotImplementedException();
        }
    }
}
