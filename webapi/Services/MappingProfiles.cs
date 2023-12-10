using DTOs;
using Models;

namespace Services;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<HotelDto, Hotel>()
            .ReverseMap();
        CreateMap<RoomDto, Room>()
            .ReverseMap();
    }
}



