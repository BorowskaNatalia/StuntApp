using Stunt.Models;

namespace Stunt.ModelsDto.Mappers;

public static class MovieHorseMapper
{
    public static MovieHorseDto ToDTO(MovieHorse movieHorse)
    {
        return new MovieHorseDto
        {
            IdHorse = movieHorse.IdHorse,
            IdMovieSet = movieHorse.IdMovieSet,
            MovieTitle = movieHorse.MovieSet.Title,  // Opcjonalnie, jeśli chcesz przekazywać tytuł filmu
            HorseName = movieHorse.Horse.Name,       // Opcjonalnie, jeśli chcesz przekazywać nazwę konia
            DepartureDate = movieHorse.DepartureDate,
            ReturnDate = movieHorse.ReturnDate
        };
    }

    public static MovieHorse ToEntity(MovieHorseDto dto)
    {
        return new MovieHorse
        {
            IdHorse = dto.IdHorse,
            IdMovieSet = dto.IdMovieSet,
            DepartureDate = dto.DepartureDate,
            ReturnDate = dto.ReturnDate
        };
    }
}