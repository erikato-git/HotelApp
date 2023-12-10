
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data;
using DTOs;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Repository;

public class HotelRepository : IHotelRepository
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public HotelRepository(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void AddHotel(Hotel Hotel)
    {
        _context.Hotels.Add(Hotel);
    }

    public async Task<HotelDto> GetHotelByIdAsync(Guid id)
    {
        return await _context.Hotels
            .ProjectTo<HotelDto>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Hotel> GetHotelEntityById(Guid id)
    {   
        return await _context.Hotels
            .Include(x => x.Rooms)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<HotelDto>> GetHotelsAsync()
    {
        var query = _context.Hotels.OrderBy(x => x.Country).AsQueryable();
        // ProjectTo works like Select just with less code
        return await query.ProjectTo<HotelDto>(_mapper.ConfigurationProvider).ToListAsync();
    }

    public void RemoveHotel(Hotel hotel)
    {
        _context.Hotels.Remove(hotel);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}


