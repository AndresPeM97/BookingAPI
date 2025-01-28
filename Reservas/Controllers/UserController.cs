using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservas.DTOs;
using Reservas.Services;

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ICommonService<UserDto, UserInsertDto, UserUpdateDto> _userService;

        public UserController(ICommonService<UserDto, UserInsertDto, UserUpdateDto> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Add(UserInsertDto userInsertDto)
        {
            var user = await _userService.Add(userInsertDto);
            
            return user != null ? Ok(user) : NotFound();
        }

        [HttpPut]
        public async Task<ActionResult<UserDto>> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.Update(userUpdateDto);
            
            return user != null ? Ok(user) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> Delete(int id)
        {
            var user = await _userService.Delete(id);
            
            return user != null ? Ok(user) : NotFound();
        }
    }
}
