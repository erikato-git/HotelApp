
using DTOs;
using Models;

namespace Interfaces;

public interface IHotelRepository
{
    Task<List<HotelDto>> GetHotelsAsync();
    Task<HotelDto> GetHotelByIdAsync(Guid id);
    Task<Hotel> GetHotelEntityById(Guid id);
    void AddHotel(Hotel Hotel);
    void RemoveHotel(Hotel Hotel);
    Task<bool> SaveChangesAsync();
}

