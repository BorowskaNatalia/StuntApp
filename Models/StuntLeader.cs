namespace Stunt.Models;

public class StuntLeader : Person
{
    
    public ICollection<Training> ConductedTrainings { get; set; }
    protected override double Earnings()
    {
        int numberOfConductedTrainings = ConductedTrainings?.Count ?? 0;
        return Salary * (1 + numberOfConductedTrainings / 100);
    }
}