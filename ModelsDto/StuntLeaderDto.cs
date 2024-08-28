namespace Stunt.ModelsDto;

public class StuntLeaderDto
{
    public int IdPerson { get; set; }
    public string Name { get;  set; }
    public string Surname { get; set; }
    public DateTime Birthdate
    {
        get;
        set;
    }
    public string Alias { get;  set; }
    public DateTime JoiningDate { get; set; }
    public double Salary { get;  set; }
}