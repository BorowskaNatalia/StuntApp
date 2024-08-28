using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces
{
        public interface IHorseService
        {
                Task<IEnumerable<HorseDto>> GetAllHorsesAsync();

                public Task<IEnumerable<HorseDto>> GetActiveHorsesAsync();
                Task<HorseDto> GetHorseByIdAsync(int id);
                Task<HorseDto> AddHorseAsync(HorseDto horseDto);
                Task<HorseDto> UpdateHorseAsync(HorseDto horseDto);
                Task<bool> DeleteHorseAsync(int id);
                Task<IEnumerable<HorseDto>> GetAvailableHorsesAsync(DateTime date);

        }
}
