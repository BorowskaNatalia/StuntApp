using System.ComponentModel.DataAnnotations;
using Stunt.Enum;

namespace Stunt.Models;

public  class Training
{
    [Key] public int IdTraining { get; set; }
    
    public int IdLocation { get; set; }
    public Location Location { get; set; }
    [Required] public DateTime DateTime { get;  set; }
    [Required] public string Description { get;  set; }
    public IEnumerable<TrainingTypeMapping> TrainingTypes;
    
    public StuntLeader StuntLeader { get; set; }
    public int IdStuntLeader { get; set; }
    public ICollection<Stuntman> Stuntmans { get; set; } = new List<Stuntman>();
    public ICollection<Horse>? Horses { get; set; }
}