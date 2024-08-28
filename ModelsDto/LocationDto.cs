using System.ComponentModel.DataAnnotations;

namespace Stunt.ModelsDto;

public class LocationDto
{
    public int IdLocation { get;  set; }
    [Required] public string Name { get;  set; }
}