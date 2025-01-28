using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservas.DTOs;
using Reservas.Services;

namespace Reservas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReserveController : ControllerBase 
    {
        private ICommonService<ReserveDto, ReserveInsertDto, ReserveUpdateDto> _reserveService;

        public ReserveController(ICommonService<ReserveDto, ReserveInsertDto, ReserveUpdateDto> service)
        {
            _reserveService = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ReserveDto>> Get()
        {
            return await _reserveService.Get();
        }

        [HttpPost]
        public async Task<ActionResult<ReserveDto>> Add(ReserveInsertDto reserveInsertDto)
        {
            var reserve = await _reserveService.Add(reserveInsertDto);
            
            return reserve != null ? Ok(reserve) : NotFound();
        }
    }
}
