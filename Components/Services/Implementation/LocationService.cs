using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation;

public class LocationService : ILocationService
{
    private readonly ApplicationDbContext _context;

    public LocationService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<LocationDto>> GetAllLocationsAsync()
    {
        var locations = await _context.Locations.ToListAsync();
        return locations.Select(LocationMapper.ToDTO).ToList();
    }

    public async Task<LocationDto> GetLocationByIdAsync(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null)
        {
            return null;
        }
        return LocationMapper.ToDTO(location);
    }

    public async Task<LocationDto> AddLocationAsync(LocationDto locationDto)
    {
        var location = LocationMapper.ToEntity(locationDto);
        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return LocationMapper.ToDTO(location);
    }
    
    public async Task<bool> LocationNameExistsAsync(string name)
    {
        return await _context.Locations.AnyAsync(l => l.Name == name);
    }
}