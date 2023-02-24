using Ananke.Application.DTOs;
using Ananke.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Domain.IServices
{
    public interface ICourseService
    {
        public Task<List<Course>> GetCoursesAsync();
        public Task<MediaProjectionDTO> GetMediaProjection(Guid id);
    }
}
