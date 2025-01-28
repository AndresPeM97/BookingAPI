using Reservas.DTOs;
using Reservas.Models;
using AutoMapper;

namespace Reservas.AutoMappers;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserInsertDto, User>();
        CreateMap<User, UserDto>().ForMember(dto => dto.Id,
            m => m.MapFrom(b => b.UserId));
        CreateMap<UserUpdateDto, User>().ForMember( dto => dto.UserId, 
            m => m.MapFrom(b => b.Id));
    }
}