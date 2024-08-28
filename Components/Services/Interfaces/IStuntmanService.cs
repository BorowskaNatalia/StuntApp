using Stunt.Models;
using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces;

public interface IStuntmanService
{
   
        Task<IEnumerable<StuntmanDto>> GetAllStuntmenAsync();
        Task<StuntmanDto> GetStuntmanByIdAsync(int id);
        Task<StuntmanDto> AddStuntmanAsync(StuntmanDto stuntmanDto);
        Task<StuntmanDto> UpdateStuntmanAsync(StuntmanDto stuntmanDto);
        Task<bool> DeleteStuntmanAsync(int id);
        Task<bool> AliasExistsAsync(string alias);
        Task UpdateSalaryAsync(int id, double newSalary);
        
        Task PromoteStuntmanAsync(int stuntmanId, string alias);


}