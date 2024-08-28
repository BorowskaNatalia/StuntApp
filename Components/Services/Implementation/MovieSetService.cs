using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.Enum;
using Stunt.Models;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation;

public class MovieSetService : IMovieSetService
{
    private readonly ApplicationDbContext _context;

    public MovieSetService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MovieSetDto>> GetAllMovieSetsAsync()
    {
        var movieSets = await _context.MovieSets
            .Include(ms => ms.Stuntmans).ThenInclude(ms => ms.Stuntman)
            .Include(ms => ms.Horses).ThenInclude(mh => mh.Horse)
            .ToListAsync();

        return movieSets.Select(MovieSetMapper.ToDTO).ToList();
    }

    public async Task<MovieSetDto> GetMovieSetByIdAsync(int id)
    {
        var movieSet = await _context.MovieSets
            .Include(ms => ms.Stuntmans).ThenInclude(ms => ms.Stuntman)
            .Include(ms => ms.Horses).ThenInclude(mh => mh.Horse)
            .FirstOrDefaultAsync(ms => ms.IdMovieSet == id);

        return movieSet != null ? MovieSetMapper.ToDTO(movieSet) : null;
    }

    public async Task<MovieSetDto> AddMovieSetAsync(MovieSetDto movieSetDto)
    {
        var movieSet = MovieSetMapper.ToEntity(movieSetDto);
        _context.MovieSets.Add(movieSet);
        await _context.SaveChangesAsync();
        return MovieSetMapper.ToDTO(movieSet);
    }

    public async Task<MovieSetDto> UpdateMovieSetAsync(MovieSetDto movieSetDto)
    {
        var movieSet = MovieSetMapper.ToEntity(movieSetDto);
        _context.MovieSets.Update(movieSet);
        await _context.SaveChangesAsync();
        return MovieSetMapper.ToDTO(movieSet);
    }

    public async Task<bool> DeleteMovieSetAsync(int id)
    {
        var movieSet = await _context.MovieSets.FindAsync(id);
        if (movieSet == null)
        {
            return false;
        }

        _context.MovieSets.Remove(movieSet);
        await _context.SaveChangesAsync();
        return true;
    }
   public async Task AddStuntmanToMovieSet(int movieSetId, int stuntmanId, DateTime departureDate, DateTime returnDate)
{
    if (!await IsStuntmanAvailableAsync(stuntmanId, departureDate, returnDate))
    {
        var overlappingMovies = await _context.MovieStuntmans
            .Include(ms => ms.MovieSet)
            .Where(ms => ms.IdPerson == stuntmanId &&
                         (ms.DepartureDate < returnDate && ms.ReturnDate > departureDate))
            .ToListAsync();

        var overlappingTrainings = await _context.Trainings
            .Include(t => t.Stuntmans)
            .Where(t => t.Stuntmans.Any(s => s.IdPerson == stuntmanId) &&
                        (t.DateTime >= departureDate && t.DateTime <= returnDate))
            .ToListAsync();

        var message = "Stuntman is not available during the specified dates.";

        if (overlappingMovies.Any())
        {
            var overlappingMovie = overlappingMovies.First();
            message += $" Already assigned to movie set '{overlappingMovie.MovieSet.Title}' from {overlappingMovie.DepartureDate} to {overlappingMovie.ReturnDate}.";
        }

        if (overlappingTrainings.Any())
        {
            foreach (var training in overlappingTrainings)
            {
                _context.Trainings.Remove(training);
            }
            await _context.SaveChangesAsync();
            message += " Stuntman has been removed from overlapping trainings.";
        }

        throw new InvalidOperationException(message);
    }

    var movieStuntman = new MovieStuntman
    {
        IdMovieSet = movieSetId,
        IdPerson = stuntmanId,
        DepartureDate = departureDate,
        ReturnDate = returnDate
    };

    _context.MovieStuntmans.Add(movieStuntman);
    await _context.SaveChangesAsync();
}



    public async Task RemoveStuntmanFromMovieSet(int movieSetId, int stuntmanId)
    {
        var movieSet = await _context.MovieSets.Include(ms => ms.Stuntmans).FirstOrDefaultAsync(ms => ms.IdMovieSet == movieSetId);
        if (movieSet == null)
        {
            throw new InvalidOperationException("Movie set not found.");
        }

        var movieStuntman = movieSet.Stuntmans.FirstOrDefault(ms => ms.IdPerson == stuntmanId);
        if (movieStuntman == null)
        {
            throw new InvalidOperationException("Stuntman is not assigned to this movie set.");
        }

        movieSet.Stuntmans.Remove(movieStuntman);
        await _context.SaveChangesAsync();
    }
    
    public async Task<bool> IsStuntmanAvailableAsync(int stuntmanId, DateTime departureDate, DateTime returnDate)
    {
        var overlappingMovies = await _context.MovieStuntmans
            .Include(ms => ms.MovieSet)
            .Where(ms => ms.IdPerson == stuntmanId &&
                         (ms.DepartureDate < returnDate && ms.ReturnDate > departureDate))
            .ToListAsync();

        var overlappingTrainings = await _context.Trainings
            .Include(t => t.Stuntmans)
            .Where(t => t.Stuntmans.Any(s => s.IdPerson == stuntmanId) &&
                        (t.DateTime >= departureDate && t.DateTime <= returnDate))
            .ToListAsync();

        return !overlappingMovies.Any() && !overlappingTrainings.Any();
    }
    
    public async Task AddHorseToMovieSetAsync(int movieSetId, int horseId, DateTime departureDate, DateTime returnDate)
    {
        if (!await IsHorseAvailableAsync(horseId, departureDate, returnDate))
        {
            throw new InvalidOperationException("The horse is not available for the selected dates.");
        }

        var overlappingMovieHorse = await _context.MovieHorses
            .AsNoTracking()
            .Where(mh => mh.IdHorse == horseId)
            .Where(mh => mh.DepartureDate <= returnDate && mh.ReturnDate >= departureDate)
            .AnyAsync();

        if (overlappingMovieHorse)
        {
            throw new InvalidOperationException("The horse is not available for the selected dates.");
        }

        var movieSet = await _context.MovieSets
            .Include(ms => ms.Horses)
            .FirstOrDefaultAsync(ms => ms.IdMovieSet == movieSetId);
        var horse = await _context.Horses
            .FirstOrDefaultAsync(h => h.IdHorse == horseId);

        if (movieSet != null && horse != null)
        {
            var movieHorse = new MovieHorse
            {
                IdHorse = horseId,
                IdMovieSet = movieSetId,
                DepartureDate = departureDate,
                ReturnDate = returnDate,
                Horse = horse,
                MovieSet = movieSet
            };

            _context.MovieHorses.Add(movieHorse);
            await _context.SaveChangesAsync();
        }
    
    }
    public async Task<bool> IsHorseAvailableAsync(int horseId, DateTime departureDate, DateTime returnDate)
    {
        var overlappingMovieHorse = await _context.MovieHorses
            .AsNoTracking()
            .AnyAsync(mh => mh.IdHorse == horseId &&
                            mh.DepartureDate <= returnDate &&
                            mh.ReturnDate >= departureDate);

        if (overlappingMovieHorse)
        {
            return false;
        }

        var overlappingTraining = await _context.Trainings
            .AsNoTracking()
            .AnyAsync(t => t.Horses.Any(h => h.IdHorse == horseId) &&
                           t.DateTime < returnDate &&
                           t.DateTime.AddHours(2) > departureDate);

        return !overlappingTraining;
    }
    
    public async Task RemoveHorseFromMovieSetAsync(int movieSetId, int horseId)
    {
        var movieHorse = await _context.MovieHorses.FirstOrDefaultAsync(mh => mh.IdMovieSet == movieSetId && mh.IdHorse == horseId);

        if (movieHorse != null)
        {
            _context.MovieHorses.Remove(movieHorse);
            await _context.SaveChangesAsync();
        }
    }
    



}