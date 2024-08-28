using Stunt.Models;

namespace Stunt.ModelsDto.Mappers;

public static class LocationMapper
{
    public static LocationDto ToDTO(Location location)
    {
        return new LocationDto
        {
            IdLocation = location.IdLocation,
            Name = location.Name
        };
    }

    public static Location ToEntity(LocationDto locationDto)
    {
        return new Location
        {
            IdLocation = locationDto.IdLocation,
            Name = locationDto.Name
        };
    }
}