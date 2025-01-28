using AutoMapper;
using Capitulo4.Repository;
using Reservas.DTOs;
using Reservas.Models;

namespace Reservas.Services;

public class RoomService : ICommonService<RoomDto, RoomInsertDto, RoomUpdateDto>
{
    private IRepository<Room> _repository;
    private IMapper _mapper;

    public RoomService(IRepository<Room> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoomDto>> Get()
    {
        var rooms = await _repository.Get();
        
        return rooms.Select(room => _mapper.Map<RoomDto>(room));
    }

    public async Task<RoomDto> GetById(int id)
    {
        var room = await _repository.GetById(id);
        if (room != null)
        {
            return _mapper.Map<RoomDto>(room);
        }
        return null;
    }

    public async Task<RoomDto> Add(RoomInsertDto roomInsertDto)
    {
        var room = _mapper.Map<Room>(roomInsertDto);
        await _repository.Add(room);
        await _repository.Save();
        
        return _mapper.Map<RoomDto>(room);
    }

    public async Task<RoomDto> Update(RoomUpdateDto roomUpdateDto)
    {
        var room = await _repository.GetById(roomUpdateDto.Id);

        if (room != null)
        {
            room = _mapper.Map(roomUpdateDto, room);
            _repository.Update(room);
            await _repository.Save();
            
            return _mapper.Map<RoomDto>(room);
        }
        return null;
    }

    public async Task<RoomDto> Delete(int id)
    {
        var room = await _repository.GetById(id);
        if (room != null)
        {
            var roomDto = _mapper.Map<RoomDto>(room);
            _repository.Delete(room);
            await _repository.Save();
            
            return roomDto;
        }

        return null;
    }
}