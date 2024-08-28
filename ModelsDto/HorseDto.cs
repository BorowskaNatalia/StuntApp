using System.ComponentModel.DataAnnotations;
using Stunt.Enum;

namespace Stunt.ModelsDto;

public class HorseDto
{
    public int IdHorse { get;  set; }
    [Required(ErrorMessage = "Name is required.")] public string Name { get;  set; }
    public DateTime Birthdate { get;  set; }
    public bool IsAvailable { get;  }
    public Status Status { get;  set; }
    public List<MovieHorseDto> Movies { get; set; }
    public List<TrainingDto> Trainings { get; set; }

}