using Stunt.Models;
using Stunt.ModelsDto;
using System.Linq;

namespace Stunt.ModelsDto.Mappers
{
    public static class HorseMapper
    {
        public static HorseDto ToDTO(Horse horse)
        {
            return new HorseDto
            {
                IdHorse = horse.IdHorse,
                Name = horse.Name,
                Birthdate = horse.Birthdate,
                Status = horse.Status,
                Movies = horse.Movies?.Select(MovieHorseMapper.ToDTO).ToList(),
                Trainings = horse.Trainings?.Select(TrainingMapper.ToDTO).ToList()
            };
        }

        public static Horse ToEntity(HorseDto dto)
        {
            return new Horse
            {
                IdHorse = dto.IdHorse,
                Name = dto.Name,
                Birthdate = dto.Birthdate,
                Status = dto.Status,
                Movies = dto.Movies?.Select(MovieHorseMapper.ToEntity).ToList(),
                Trainings = dto.Trainings?.Select(TrainingMapper.ToEntity).ToList()
            };
        }
    }
}