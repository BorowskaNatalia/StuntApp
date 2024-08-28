using System.ComponentModel.DataAnnotations;
using Stunt.Enum;
using Stunt.Models;

namespace Stunt.ModelsDto;

public class StuntmanDto
{
   public int IdPerson { get; set; }
   
   [Required(ErrorMessage = "Name is required.")] public string Name { get;  set; }
   [Required(ErrorMessage = "Surname is required.")] public string Surname { get; set; }
   
   [Required(ErrorMessage = "Rank is required.")] public Rank Rank { get; set; }
   [Required(ErrorMessage = "Birthdate is required.")] public DateTime Birthdate { get; set; }
    public string Alias { get;  set; }
    [Required(ErrorMessage = "Joining date is required.")]public DateTime JoiningDate { get; set; }
    public double Salary { get;  set; }
    
    public List<TrainingDto> Trainings { get; set; }
    public List<MovieStuntmanDto> MovieSets { get; set; } = new List<MovieStuntmanDto>();
}