using api.Dtos.Users;
using api.Interface.Services;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;


        public UsersController(IUserService service)
        {
            _service = service;
        }


        [HttpPost("seeker")]
        public async Task<IActionResult> CreateSeeker(CreateUserDto dto)
        {
            var result = await _service.CreateSeekerAsync(dto);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateUserDto dto)
        {
            var result = await _service.UpdateUserAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDelete(Guid id)
        {
            var success = await _service.DeactivateUserAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

    }
}