using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces;

public interface ILocationService
{
    Task<IEnumerable<LocationDto>> GetAllLocationsAsync();
    Task<LocationDto> GetLocationByIdAsync(int id);
    Task<LocationDto> AddLocationAsync(LocationDto locationDto);
    Task<bool> LocationNameExistsAsync(string name);
}