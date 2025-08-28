using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Interfaces;

namespace StudentRegistration.Api.Controllers.Subjects
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(Guid idStudent)
        {
            var apiResponse = await _subjectService.GetSubjectsValids(idStudent);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> registerSubjectByStudent(AddSubjectByStudentDTO subjectByStudentDTO)
        {
            var apiResponse = await _subjectService.registerSubjectByStudent(subjectByStudentDTO);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }
    }
}
