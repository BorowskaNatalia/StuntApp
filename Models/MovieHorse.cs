using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stunt.Models;

public class MovieHorse
{
    [Required]
    public int IdHorse { get; set; }

    [ForeignKey(nameof(IdHorse))]
    public Horse Horse { get; set; }

    [Required]
    public int IdMovieSet { get; set; }

    [ForeignKey(nameof(IdMovieSet))]
    public MovieSet MovieSet { get; set; }

    [Required]
    public DateTime DepartureDate { get; set; }

    [Required]
    public DateTime ReturnDate { get; set; }

    [NotMapped]
    public bool IsValid => ReturnDate > DepartureDate;
}