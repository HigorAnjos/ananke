using Ananke.Domain.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseServices)
        {
            _courseService = courseServices;
        }
      
        [HttpGet("get-all-courses")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCouses()
        {
            return Ok(await _courseService.GetCoursesAsync());
        }

        [HttpGet("get-media-projection")]
        [AllowAnonymous]
        public async Task<IActionResult> GetMediaProjection(Guid id)
        {
            return Ok(await _courseService.GetMediaProjection(id));
        }
    }
}