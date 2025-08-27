using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Interfaces;

namespace StudentRegistration.Api.Controllers.Students
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(int actualPage, int recordsQuantity)
        {
            var apiResponse = await _studentsService.GetStudents(actualPage, recordsQuantity);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsId(Guid id)
        {
            var apiResponse = await _studentsService.GetStudentsId(id);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);

        }

        [HttpGet("GetSubjectsByStudent")]
        public async Task<IActionResult> GetSubjectsByStudent(Guid id)
        {
            var apiResponse = await _studentsService.GetSubjectsByStudent(id);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgram(AddStudentDTO student)
        {
            var apiResponse = await _studentsService.UpdateStudent(student);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProgram(Guid id)
        {
            var apiResponse = await _studentsService.DeleteStudent(id);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }
    }
}
