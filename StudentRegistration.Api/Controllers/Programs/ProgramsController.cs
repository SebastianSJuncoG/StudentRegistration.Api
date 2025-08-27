using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Interfaces;
using StudentRegistration.Services.Responces;

namespace StudentRegistration.Api.Controllers.Programs
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgramsController : ControllerBase
    {
        private readonly IProgramService _programService;

        public ProgramsController(IProgramService programService)
        {
            _programService = programService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var apiResponse = await _programService.GetPrograms();

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProgramId(int id)
        {
            var apiResponse = await _programService.GetProgramId(id);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpGet("GetProgramByName")]
        public async Task<IActionResult> GetProgramByName(string programName)
        {
            var apiResponse = await _programService.GetProgramByName(programName);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddProgram(ProgramDTO program)
        {
            var apiResponse = await _programService.AddProgram(program);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgram(ProgramDTO program)
        {
            var apiResponse = await _programService.UpdateProgram(program);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProgram(int id)
        {
            var apiResponse = await _programService.DeleteProgram(id);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }
    }
}
