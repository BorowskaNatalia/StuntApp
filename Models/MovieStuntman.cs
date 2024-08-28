using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stunt.Models;

public class MovieStuntman
{
    [Key]
    public int MovieStuntmanId { get; set; }

    [Required]
    public int IdMovieSet { get; set; }

    [ForeignKey(nameof(IdMovieSet))]
    public MovieSet MovieSet { get; set; }

    [Required]
    public int IdPerson { get; set; }

    [ForeignKey(nameof(IdPerson))]
    public Stuntman Stuntman { get; set; }

    [Required]
    public DateTime DepartureDate { get; set; }

    [Required]
    public DateTime ReturnDate { get; set; }

    [NotMapped]
    public bool IsValid => ReturnDate > DepartureDate;
}
