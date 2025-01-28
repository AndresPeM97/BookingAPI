using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservas.DTOs;
using Reservas.Models;
using Reservas.Services;

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private ICommonService<RoomDto, RoomInsertDto, RoomUpdateDto> _commonService;

        public RoomController(ICommonService<RoomDto, RoomInsertDto, RoomUpdateDto> commonService)
        {
            _commonService = commonService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<RoomDto>> Get()
        {
            return await _commonService.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetById(int id)
        {
            var room = await _commonService.GetById(id);
            return room != null ? Ok(room): NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> Add(RoomInsertDto room)
        {
            var RoomDto = await _commonService.Add(room);
            
            return CreatedAtAction(nameof(GetById), new { id = RoomDto.Id }, RoomDto);
        }

        [HttpPut]
        public async Task<ActionResult<RoomDto>> Update(RoomUpdateDto room)
        {
            var RoomDto = await _commonService.Update(room);
            
            return RoomDto != null ? Ok(RoomDto) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RoomDto>> Delete(int id)
        {
            var RoomDto = await _commonService.Delete(id);
            
            return RoomDto != null ? Ok(RoomDto) : NotFound();
        }
    }
}
