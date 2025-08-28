using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Services.DTOs;
using StudentRegistration.Services.Implementations;
using StudentRegistration.Services.Interfaces;

namespace StudentRegistration.Api.Controllers.UsersLogin
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersLoginController : ControllerBase
    {
        private readonly IUsersLoginService _usersLoginService;

        public UsersLoginController(IUsersLoginService usersLoginService)
        {
            _usersLoginService = usersLoginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            var apiResponse = await _usersLoginService.GetUserByUserName(userName);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserDTO user)
        {
            var apiResponse = await _usersLoginService.AddUser(user);

            if (apiResponse.Status == 200) return Ok(apiResponse);

            if (apiResponse.Status == 400) return BadRequest(apiResponse);

            return NotFound(apiResponse);
        }
    }
}
