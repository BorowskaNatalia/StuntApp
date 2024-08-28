using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.Enum;
using Stunt.Models;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation;

public class TrainingService : ITrainingService
{
    private readonly ApplicationDbContext _context;

    public TrainingService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<TrainingDto>> GetAllTrainingsAsync()
    {
        try
        {
            var trainings = await _context.Trainings
                .Include(t => t.TrainingTypes)
                .Include(t => t.Stuntmans)
                .Include(t => t.Horses)
                .ToListAsync();

            Console.WriteLine($"TrainingService fetched {trainings.Count} trainings.");
            return trainings.Select(TrainingMapper.ToDTO).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in GetAllTrainingsAsync: {ex.Message}");
            throw;
        }
    }

    public async Task<TrainingDto> GetTrainingByIdAsync(int id)
    {
        var training = await _context.Trainings
            .Include(t => t.Stuntmans)
            .Include(t => t.Horses)
            .Include(t => t.Location)
            .Include(t => t.StuntLeader)
            .Include(t => t.TrainingTypes)
            .FirstOrDefaultAsync(t => t.IdTraining == id);

        if (training == null) return null;

        return TrainingMapper.ToDTO(training);
    }



    public async Task<TrainingDto> UpdateTrainingAsync(TrainingDto trainingDto)
    {
        var training = TrainingMapper.ToEntity(trainingDto);
        _context.Trainings.Update(training);
        await _context.SaveChangesAsync();
        return TrainingMapper.ToDTO(training);
    }
    
    public async Task<TrainingDto> AddTrainingAsync(TrainingDto trainingDto)
    {
        
        var existingTraining = await _context.Trainings
            .FirstOrDefaultAsync(t => t.IdLocation == trainingDto.IdLocation && t.DateTime == trainingDto.DateTime);

        if (existingTraining != null)
        {
            throw new InvalidOperationException("A training with the same location and date/time already exists.");
        }
        

        var training = TrainingMapper.ToEntity(trainingDto);
        _context.Trainings.Add(training);
        await _context.SaveChangesAsync();
        return TrainingMapper.ToDTO(training);
    }
    public async Task<bool> IsStuntmanAvailable(int stuntmanId, DateTime dateTime)
    {
        var overlappingTrainings = await _context.Trainings
            .Include(t => t.Stuntmans)
            .Where(t => t.Stuntmans.Any(s => s.IdPerson == stuntmanId) && t.DateTime == dateTime)
            .ToListAsync();

        var overlappingMovies = await _context.MovieStuntmans
            .Include(ms => ms.MovieSet)
            .Where(ms => ms.IdPerson == stuntmanId &&
                         (ms.DepartureDate <= dateTime && ms.ReturnDate >= dateTime))
            .ToListAsync();

        return !overlappingTrainings.Any() && !overlappingMovies.Any();
    }

    public async Task AddStuntmanToTraining(int trainingId, int stuntmanId)
    {
        var training = await _context.Trainings
            .Include(t => t.Stuntmans)
            .FirstOrDefaultAsync(t => t.IdTraining == trainingId);

        if (training != null)
        {
            if (await IsStuntmanAvailable(stuntmanId, training.DateTime))
            {
                var stuntman = await _context.Stuntmen
                    .Include(s => s.Trainings)
                    .FirstOrDefaultAsync(s => s.IdPerson == stuntmanId);

                if (stuntman != null)
                {
                    training.Stuntmans.Add(stuntman);
                    stuntman.Trainings.Add(training);
                    await _context.SaveChangesAsync();
                }
            }
            else
            {
                throw new InvalidOperationException("Stuntman is already assigned to another training/movieset at this time.");
            }
        }
    }
    
    public async Task<IEnumerable<TrainingDto>> GetTrainingsByStuntmanIdAsync(int stuntmanId)
    {
        var trainings = await _context.Trainings
            .Where(t => t.Stuntmans.Any(s => s.IdPerson == stuntmanId))
            .ToListAsync();

        return trainings.Select(TrainingMapper.ToDTO);
    }

    public async Task RemoveStuntmanFromTraining(int trainingId, int stuntmanId)
    {
        var training = await _context.Trainings
            .Include(t => t.Stuntmans)
            .FirstOrDefaultAsync(t => t.IdTraining == trainingId);

        if (training != null)
        {
            var stuntman = training.Stuntmans.FirstOrDefault(s => s.IdPerson == stuntmanId);
            if (stuntman != null)
            {
                training.Stuntmans.Remove(stuntman);
                await _context.SaveChangesAsync();
            }
        }
    }
    
    public async Task AddHorseToTraining(int trainingId, int horseId)
    {
        var training = await _context.Trainings
            .Include(t => t.Horses)
            .FirstOrDefaultAsync(t => t.IdTraining == trainingId);

        if (training == null)
        {
            throw new InvalidOperationException("Training not found.");
        }
        var horse = await _context.Horses
            .Include(h => h.Trainings)
            .FirstOrDefaultAsync(h => h.IdHorse == horseId);
        
        if (horse.Status == Status.Pensioner)
        {
            throw new InvalidOperationException("Cannot add a horse with the status 'Pensioner' to the training.");
        }

   
        if (horse == null)
        {
            throw new InvalidOperationException("Horse not found.");
        }

        if (horse.Trainings.Any(t => t.DateTime == training.DateTime))
        {
            throw new InvalidOperationException("Horse is not available at the selected time.");
        }

        training.Horses.Add(horse);
        await _context.SaveChangesAsync();
    }
    public async Task<IEnumerable<TrainingDto>> GetFutureTrainingsForHorseAsync(int horseId)
    {
        var futureDate = DateTime.Now;
        var futureTrainings = await _context.Trainings
            .Include(t => t.Horses)
            .Where(t => t.DateTime >= futureDate && t.Horses.Any(h => h.IdHorse == horseId))
            .ToListAsync();

        return futureTrainings.Select(TrainingMapper.ToDTO);
    }

    public async Task RemoveHorseFromTraining(int horseId, int trainingId)
    {
        var training = await _context.Trainings
            .Include(t => t.Horses)
            .FirstOrDefaultAsync(t => t.IdTraining == trainingId);

        if (training == null)
        {
            throw new InvalidOperationException("Training not found.");
        }

        var horse = training.Horses.FirstOrDefault(h => h.IdHorse == horseId);
        if (horse == null)
        {
            throw new InvalidOperationException("Horse is not assigned to this training.");
        }

        training.Horses.Remove(horse);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteTrainingAsync(int trainingId)
    {
        var training = await _context.Trainings
            .Include(t => t.Stuntmans)
            .Include(t => t.Horses)
            .FirstOrDefaultAsync(t => t.IdTraining == trainingId);

        if (training == null)
        {
            throw new InvalidOperationException("Training not found.");
        }

        _context.Trainings.Remove(training);
        await _context.SaveChangesAsync();
    }


}