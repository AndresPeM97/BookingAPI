using AutoMapper;
using Capitulo4.Repository;
using Reservas.DTOs;
using Reservas.Models;

namespace Reservas.Services;

public class ReserveService : ICommonService<ReserveDto, ReserveInsertDto, ReserveUpdateDto>
{
    private IRepository<Reserve> _reserveRepository;
    private IMapper _mapper;

    public ReserveService(IRepository<Reserve> reserveRepository, IMapper mapper)
    {
        _reserveRepository = reserveRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ReserveDto>> Get()
    {
        var reserves = await _reserveRepository.Get();
        
        return reserves.Select(room => _mapper.Map<ReserveDto>(room));
    }

    public async Task<ReserveDto> GetById(int id)
    {
        var reserve = await _reserveRepository.GetById(id);
        if (reserve != null)
        {
            return _mapper.Map<ReserveDto>(reserve);
        }
        return null;
    }

    public async Task<ReserveDto> Add(ReserveInsertDto reserveInsertDto)
    {
        var reserve = _mapper.Map<Reserve>(reserveInsertDto);
        await _reserveRepository.Add(reserve);
        await _reserveRepository.Save();
        
        return _mapper.Map<ReserveDto>(reserve);
    }

    public Task<ReserveDto> Update(ReserveUpdateDto reserveUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<ReserveDto> Delete(int id)
    {
        throw new NotImplementedException();
    }
}