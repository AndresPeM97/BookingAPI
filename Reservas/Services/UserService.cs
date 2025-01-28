using AutoMapper;
using Capitulo4.Repository;
using Reservas.DTOs;
using Reservas.Models;

namespace Reservas.Services;

public class UserService : ICommonService<UserDto, UserInsertDto, UserUpdateDto>
{
    private IRepository<User> _repository;
    private IMapper _mapper;

    public UserService(IRepository<User> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserDto>> Get()
    {
        var users = await _repository.Get();
        
        return users.Select(user => _mapper.Map<UserDto>(user));
    }

    public async Task<UserDto> GetById(int id)
    {
        var user = await _repository.GetById(id);

        if (user != null)
        {
            return _mapper.Map<UserDto>(user);
        }
        
        return null;
        
    }

    public async Task<UserDto> Add(UserInsertDto userInsertDto)
    {
        var user = _mapper.Map<User>(userInsertDto);
        await _repository.Add(user);
        await _repository.Save();
        
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> Update(UserUpdateDto userUpdateDto)
    {
        var user = await _repository.GetById(userUpdateDto.Id);

        if (user != null)
        {
            user  = _mapper.Map(userUpdateDto, user);
            _repository.Update(user);
            await _repository.Save();
            
            return _mapper.Map<UserDto>(user);
            
        }
        return null;
    }

    public async Task<UserDto> Delete(int id)
    {
        var user = await _repository.GetById(id);
        if (user != null)
        {
            var userDto = _mapper.Map<UserDto>(user);
            
            _repository.Delete(user);
            await _repository.Save();
            
            return userDto;
        }
        
        return null;
    }
}