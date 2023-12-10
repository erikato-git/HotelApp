
using AutoMapper;
using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

[ApiController]
[Route("api/Hotels")]
public class HotelsController: ControllerBase
{
    private readonly IHotelRepository _repo;
    private readonly IMapper _mapper;

    public HotelsController(IHotelRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<HotelDto>>> GetAllHotels()
    {
        return await _repo.GetHotelsAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotelById(Guid id)
    {
        var hotel = await _repo.GetHotelByIdAsync(id);
        
        if(hotel == null) return NotFound();

        return hotel;
        
    }

    [HttpGet("Entity/{id}")]
    public async Task<ActionResult<Hotel>> GetHotelEntityById(Guid id)
    {
        var hotel = await _repo.GetHotelEntityById(id);

        if(hotel == null) return NotFound();

        return hotel;
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<HotelDto>> CreateHotel(HotelDto hotelDto)
    {
        var hotel = _mapper.Map<Hotel>(hotelDto);

        hotel.CreatedBy = User.Identity.Name;

        _repo.AddHotel(hotel);

        var newHotel = _mapper.Map<HotelDto>(hotel);

        var result = await _repo.SaveChangesAsync();

        if(!result) return BadRequest("Could not save changes to DB");

        // Returns url for 'GetHotelById' with the status-code 201
        return CreatedAtAction(nameof(GetHotelById), 
            new { hotel.Id }, newHotel);
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult> UpdateHotel(Guid id, UpdateHotelDto updateHotelDto)
    {
        var hotel = await _repo.GetHotelByIdAsync(id);

        if(hotel == null) return NotFound();

        if(hotel.CreatedBy != User.Identity.Name) return Forbid();

        hotel.HotelName = updateHotelDto.HotelName ?? hotel.HotelName;
        hotel.Street = updateHotelDto.Street ?? hotel.Street;
        hotel.City = updateHotelDto.City ?? hotel.City;
        hotel.Country = updateHotelDto.Country ?? hotel.Country;
        hotel.Stars = updateHotelDto.Stars ?? hotel.Stars;
        hotel.Description = updateHotelDto.Description ?? hotel.Description;
        hotel.BackgroundImage = updateHotelDto.BackgroundImage ?? hotel.BackgroundImage;
        hotel.CreatedBy = updateHotelDto.CreatedBy ?? hotel.CreatedBy;

        var result = await _repo.SaveChangesAsync();

        if(result) return Ok();

        return BadRequest("Problem saving changes");
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHotel(Guid id)
    {
        var hotel = await _repo.GetHotelEntityById(id);     // Object carries related objects

        if(hotel == null) return NotFound();

        if(hotel.CreatedBy != User.Identity.Name) return Forbid();

        _repo.RemoveHotel(hotel);

        var result = await _repo.SaveChangesAsync();

        if(!result) return BadRequest("Could not update DB");

        return Ok();
    }

}



