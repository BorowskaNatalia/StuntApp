namespace Stunt.ModelsDto
{
    public class MovieStuntmanDto
    {
        public int IdMovieSet { get; set; }
        public int IdPerson { get; set; }
        public string MovieTitle { get; set; }  
        public string StuntmanName { get; set; } 
        public DateTime DepartureDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}