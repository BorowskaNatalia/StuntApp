namespace Stunt.ModelsDto;

public class MovieSetDto
{
    public int IdMovieSet{ get;  set; }
    public string Title { get;  set; }
    public double Budget { get; set; } 
    public  string Address { get; set; } 
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<MovieStuntmanDto> Stuntmen { get; set; } = new List<MovieStuntmanDto>();
    public List<MovieHorseDto> Horses { get; set; } = new List<MovieHorseDto>();

}