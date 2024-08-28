using Stunt.Models;
using Stunt.ModelsDto;
using System.Linq;

namespace Stunt.ModelsDto.Mappers
{
    public static class StuntmanMapper
    {
        public static StuntmanDto ToDTO(Stuntman stuntman)
        {
            return new StuntmanDto
            {
                IdPerson = stuntman.IdPerson,
                Name = stuntman.Name,
                Surname = stuntman.Surname,
                Birthdate = stuntman.Birthdate,
                Alias = stuntman.Alias,
                JoiningDate = stuntman.JoiningDate,
                Salary = stuntman.Salary,
                Rank = stuntman.Rank,
                MovieSets = stuntman.MovieSets?.Select(MovieStuntmanMapper.ToDTO).ToList()
            };
        }

        public static Stuntman ToEntity(StuntmanDto dto)
        {
            return new Stuntman
            {
                IdPerson = dto.IdPerson,
                Name = dto.Name,
                Surname = dto.Surname,
                Birthdate = dto.Birthdate,
                Alias = dto.Alias,
                JoiningDate = dto.JoiningDate,
                Salary = dto.Salary,
                Rank = dto.Rank,
                MovieSets = dto.MovieSets?.Select(MovieStuntmanMapper.ToEntity).ToList()
            };
        }
    }
}