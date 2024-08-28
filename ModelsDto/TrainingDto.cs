using System.ComponentModel.DataAnnotations;
using Stunt.Models;
using Stunt.ModelsDto;

public class TrainingDto
{
    public int IdTraining { get; set; }
    public int IdLocation { get; set; }
    [Required] public DateTime DateTime { get; set; }
    [Required] public string Description { get; set; }
    public List<TrainingTypeMappingDto> TrainingTypes { get; set; } = new List<TrainingTypeMappingDto>();
    public StuntLeader StuntLeader  { get; set; }
    public int IdStuntLeader { get; set; }
    public List<StuntmanDto> Stuntmen { get; set; } = new List<StuntmanDto>();
    public List<HorseDto> Horses { get; set; } = new List<HorseDto>();
}