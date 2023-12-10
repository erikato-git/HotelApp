using DTOs;
using Models;

namespace Services;

public class MappingProfiles : AutoMapper.Profile
{
    public MappingProfiles()
    {
        CreateMap<HotelDto, Hotel>();
            // .IncludeMembers(x => x.Rooms);
            // .ReverseMap();
        CreateMap<RoomDto, Room>()
            .ReverseMap();
    }
}



