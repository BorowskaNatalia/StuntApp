using System.ComponentModel.DataAnnotations;

namespace Stunt.Models;

public class Location
{
   [Key] public int IdLocation { get;  set; }
    [Required] public string Name { get;  set; }
    
    public ICollection<Training> Trainings { get;  set; }
   
}