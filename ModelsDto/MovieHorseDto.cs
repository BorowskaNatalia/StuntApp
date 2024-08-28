namespace Stunt.ModelsDto;

public class MovieHorseDto
{
    public int IdHorse { get; set; }
    public int IdMovieSet { get; set; }
    public string MovieTitle { get; set; }
    public string HorseName { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }
}