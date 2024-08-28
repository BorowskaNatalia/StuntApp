using Stunt.ModelsDto;

namespace Stunt.Components.Services.Interfaces;

public interface ITrainingService
{
    Task<IEnumerable<TrainingDto>> GetAllTrainingsAsync();
    Task<TrainingDto> GetTrainingByIdAsync(int id);
    Task<TrainingDto> AddTrainingAsync(TrainingDto trainingDto);
    Task<TrainingDto> UpdateTrainingAsync(TrainingDto trainingDto);
    Task AddStuntmanToTraining(int trainingId, int stuntmanId);
    Task<bool> IsStuntmanAvailable(int stuntmanId, DateTime trainingDateTime);
    public Task<IEnumerable<TrainingDto>> GetTrainingsByStuntmanIdAsync(int stuntmanId);
    public Task RemoveStuntmanFromTraining(int trainingId, int stuntmanId);
    
    Task AddHorseToTraining(int trainingId, int horseId);

    Task<IEnumerable<TrainingDto>> GetFutureTrainingsForHorseAsync(int horseId);
    Task RemoveHorseFromTraining(int horseId, int trainingId);
    
    Task DeleteTrainingAsync(int trainingId);

}