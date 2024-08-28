using Stunt.Enum;
using Stunt.Models;

namespace Stunt.ModelsDto;

public class GroupTrainingDto : TrainingDto
{
    public Difficulty Difficulty { get; set; }
}