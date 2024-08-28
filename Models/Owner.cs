namespace Stunt.Models;

public class Owner : Person
{
    protected override double Earnings()
    {
        double yearsWorked = (DateTime.Now - JoiningDate).TotalDays / 365.25;
        return Salary * (1 + yearsWorked / 10);
    }
}