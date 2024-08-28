using System.ComponentModel.DataAnnotations;
using Stunt.Enum;

namespace Stunt.Models;

public class Horse
{
    [Key][Required] public int IdHorse { get;  set; }
    [Required] public string Name { get;  set; }
    [Required] public DateTime Birthdate { get;  set; }
    [Required] public bool isAvailable { get;  set; }
    [Required] public Status Status { get;  set; }
    
    public ICollection<MovieHorse>? Movies { get;  set; }
    public ICollection<Training>? Trainings { get;  set; }
}