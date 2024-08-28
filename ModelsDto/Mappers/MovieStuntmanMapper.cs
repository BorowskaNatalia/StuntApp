using Stunt.Models;
using Stunt.ModelsDto;

namespace Stunt.ModelsDto.Mappers
{
    public static class MovieStuntmanMapper
    {
        public static MovieStuntmanDto ToDTO(MovieStuntman movieStuntman)
        {
            return new MovieStuntmanDto
            {
                IdMovieSet = movieStuntman.IdMovieSet,
                IdPerson = movieStuntman.IdPerson,
                MovieTitle = movieStuntman.MovieSet?.Title,
                StuntmanName = $"{movieStuntman.Stuntman?.Name} {movieStuntman.Stuntman?.Surname}",
                DepartureDate = movieStuntman.DepartureDate,
                ReturnDate = movieStuntman.ReturnDate
            };
        }

        public static MovieStuntman ToEntity(MovieStuntmanDto dto)
        {
            return new MovieStuntman
            {
                IdMovieSet = dto.IdMovieSet,
                IdPerson = dto.IdPerson,
                DepartureDate = dto.DepartureDate,
                ReturnDate = dto.ReturnDate
            };
        }
    }
}