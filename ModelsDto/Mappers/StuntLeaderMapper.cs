using Stunt.Models;
using Stunt.ModelsDto;

namespace Stunt.ModelsDto.Mappers
{
    public static class StuntLeaderMapper
    {
        public static StuntLeaderDto ToDTO(StuntLeader stuntLeader)
        {
            return new StuntLeaderDto
            {
                IdPerson = stuntLeader.IdPerson,
                Name = stuntLeader.Name,
                Surname = stuntLeader.Surname,
                Birthdate = stuntLeader.Birthdate,
                Alias = stuntLeader.Alias,
                JoiningDate = stuntLeader.JoiningDate,
                Salary = stuntLeader.Salary
            };
        }

        public static StuntLeader ToEntity(StuntLeaderDto stuntLeaderDto)
        {
            return new StuntLeader
            {
                IdPerson = stuntLeaderDto.IdPerson,
                Name = stuntLeaderDto.Name,
                Surname = stuntLeaderDto.Surname,
                Birthdate = stuntLeaderDto.Birthdate,
                Alias = stuntLeaderDto.Alias,
                JoiningDate = stuntLeaderDto.JoiningDate,
                Salary = stuntLeaderDto.Salary
            };
        }
    }
}