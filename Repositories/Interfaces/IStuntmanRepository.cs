using Stunt.Enum;
using Stunt.ModelsDto;

namespace Stunt.Repositories.Interfaces;

public interface IStuntmanRepository
{
    public Task<StatusEnum> AddStuntmanAsync(StuntmanDto stuntmanDto);
    public Task<dynamic> GetAllStuntmenAsync();
    public Task<dynamic> GetAllCadetsAsync();
    public Task<StatusEnum> AddCadetAsync(CadetDto cadetDto);
    public Task<dynamic> GetStuntmanByIdAsync(int id);
    public Task<dynamic> GetCadetByIdAsync(int id);
}