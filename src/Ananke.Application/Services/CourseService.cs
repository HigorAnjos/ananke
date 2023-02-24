using Ananke.Application.DTOs;
using Ananke.Domain.Entities;
using Ananke.Domain.IServices;
using Ananke.Domain.Repository;
using AutoMapper;

namespace Ananke.Application.Services
{
    public class CourseService : ICourseService
    {
        private IScrapingRepository _scrapingRepository;
        private readonly IMapper _mapper;
        public CourseService(IScrapingRepository scrapingRepository, IMapper mapper)
        {
            _scrapingRepository= scrapingRepository;
            _mapper= mapper;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _scrapingRepository.GetCoursesAsync();
        }

        public async Task<MediaProjectionDTO> GetMediaProjection(Guid id)
        {
            var courses = await _scrapingRepository.GetCoursesAsync();
            // var couseFoud = courses.Find(x => x.Id == id);
            var couseFoud = courses[0];
            return _mapper.Map<MediaProjectionDTO>(couseFoud);
        }
    }
}
