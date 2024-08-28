namespace Stunt.ModelsDto;

public class CadetDto
{
    public int IdPerson { get; set; }
    public string Name { get;  set; }
    public string Surname { get; set; }
    public DateTime Birthdate
    {

        get;
        set;
    }
    public DateTime JoiningDate { get; set; }
    public double Salary { get;  set; }
}