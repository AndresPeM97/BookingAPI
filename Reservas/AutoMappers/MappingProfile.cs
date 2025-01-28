using AutoMapper;
using Reservas.DTOs;
using Reservas.Models;

namespace Reservas.AutoMappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RoomInsertDto, Room>();
        CreateMap<Room, RoomDto>().ForMember(dto => dto.Id,
            m => m.MapFrom(b => b.RoomId));
        CreateMap<RoomUpdateDto, Room>().ForMember( dto => dto.RoomId, 
            m => m.MapFrom(b => b.Id));
        
        CreateMap<UserInsertDto, User>();
        CreateMap<User, UserDto>().ForMember(dto => dto.Id,
            m => m.MapFrom(b => b.UserId));
        CreateMap<UserUpdateDto, User>().ForMember( dto => dto.UserId, 
            m => m.MapFrom(b => b.Id));
        
        CreateMap<ReserveInsertDto, Reserve>().ForMember(dto => dto.ReserveOwner,
            m => m.MapFrom(b => b.OwnerName));
        
        CreateMap<Reserve, ReserveDto>().ForMember(dto => dto.OwnerName,
            m => m.MapFrom(b => b.ReserveOwner));

    }
}