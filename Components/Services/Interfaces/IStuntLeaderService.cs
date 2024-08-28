using System.Collections.Generic;
using System.Threading.Tasks;
using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces
{
    public interface IStuntLeaderService
    {
        Task<IEnumerable<StuntLeaderDto>> GetAllStuntLeadersAsync();
        Task<StuntLeaderDto> GetStuntLeaderByIdAsync(int id);
        Task<StuntLeaderDto> AddStuntLeaderAsync(StuntLeaderDto stuntLeaderDto);
        Task<StuntLeaderDto> UpdateStuntLeaderAsync(StuntLeaderDto stuntLeaderDto);
        Task<bool> DeleteStuntLeaderAsync(int id);
    }
}