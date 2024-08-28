using Stunt.Models;
using Stunt.ModelsDto;

namespace Stunt.ModelsDto.Mappers
{
    public static class MovieSetMapper
    {
        public static MovieSetDto ToDTO(MovieSet movieSet)
        {
            return new MovieSetDto
            {
                IdMovieSet = movieSet.IdMovieSet,
                Title = movieSet.Title,
                Budget = movieSet.Budget,
                Address = movieSet.Address,
                StartDate = movieSet.StartDate,
                EndDate = movieSet.EndDate,
                Stuntmen = movieSet.Stuntmans?.Select(MovieStuntmanMapper.ToDTO).ToList() ?? new List<MovieStuntmanDto>(),
                Horses = movieSet.Horses?.Select(MovieHorseMapper.ToDTO).ToList() ?? new List<MovieHorseDto>()
            };
        }

        public static MovieSet ToEntity(MovieSetDto movieSetDto)
        {
            return new MovieSet
            {
                IdMovieSet = movieSetDto.IdMovieSet,
                Title = movieSetDto.Title,
                Budget = movieSetDto.Budget,
                Address = movieSetDto.Address,
                StartDate = movieSetDto.StartDate,
                EndDate = movieSetDto.EndDate,
                Stuntmans = movieSetDto.Stuntmen?.Select(MovieStuntmanMapper.ToEntity).ToList() ?? new List<MovieStuntman>(),
                Horses = movieSetDto.Horses?.Select(MovieHorseMapper.ToEntity).ToList() ?? new List<MovieHorse>()
            };
        }
    }
}