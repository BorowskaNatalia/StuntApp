using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces;

public interface IMovieSetService
{
    Task<IEnumerable<MovieSetDto>> GetAllMovieSetsAsync();
    Task<MovieSetDto> GetMovieSetByIdAsync(int id);
    Task<MovieSetDto> AddMovieSetAsync(MovieSetDto movieSetDto);
    Task<MovieSetDto> UpdateMovieSetAsync(MovieSetDto movieSetDto);
    Task<bool> DeleteMovieSetAsync(int id);
    Task AddStuntmanToMovieSet(int movieSetId, int stuntmanId, DateTime departureDate, DateTime returnDate);

    Task RemoveStuntmanFromMovieSet(int movieSetId, int stuntmanId);
    Task<bool> IsStuntmanAvailableAsync(int stuntmanId, DateTime departureDate, DateTime returnDate);
    Task AddHorseToMovieSetAsync(int movieSetId, int horseId, DateTime departureDate, DateTime returnDate);

    Task RemoveHorseFromMovieSetAsync(int movieSetId, int horseId);
    Task<bool> IsHorseAvailableAsync(int horseId, DateTime departureDate, DateTime returnDate);


}