using Ananke.Application.IServices;
using Ananke.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebApi.Requests;

namespace Presentation.WebApi.Controllers
{
    public class StudentController
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] StudentLoginRequest request)
        {
            return new ObjectResult(await _studentServices.Login(request.Email, request.Password));
        }

        //[HttpPost]
        //[AllowAnonymous]
        //public async Task<IActionResult> Register(StudentRequest studentBody)
        //{

        //}

        //[HttpGet]
        //[Authorize(policy: "Student")]
        //public async Task<IActionResult> GetStudent()
        //{

        //}

        //[HttpPut]
        //[Authorize(policy: "Student")]
        //public async Task<IActionResult> Update(StudentRequest studentBody)
        //{

        //}

        //[HttpDelete("{id:Guid}")]
        //[Authorize(policy: "Student")]
        //public async Task<IActionResult> Delete(Guid id)
        //{

        //}
    }
}
