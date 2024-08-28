using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stunt.Models;

public class MovieSet
{
    [Key]  public int IdMovieSet{ get;  set; }
    [Required] public string Title { get;  set; }
    [Required] public string Address { get;  set; }
    [AllowNull] public double Budget { get; set; }
    [Required] public DateTime StartDate { get; set; }
    [Required] public DateTime EndDate { get; set; }

    public ICollection<MovieStuntman> Stuntmans { get;  set; }
    public ICollection<MovieHorse> Horses { get;  set; }
    
}