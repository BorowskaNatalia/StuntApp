using Stunt.Enum;

namespace Stunt.Models;

public class TrainingTypeMapping
{
    public int TrainingId { get; set; }
    public Training Training { get; set; }
    public TrainingType TrainingType { get; set; }
}