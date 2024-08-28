using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Stunt.Enum;

namespace Stunt.Models;

public class Stuntman : Person
{
    [Required] public Rank Rank { get;  set; }
    
    public ICollection<Training> Trainings { get; set; }
    public ICollection<MovieStuntman>? MovieSets { get;  set; }
    protected override double Earnings()
    {
        if (Rank == Rank.Cadet)
        {
            return Salary;
        }
        else
        {
            int numberOfMovieSets = MovieSets?.Count ?? 0;
            return Salary * (1 + numberOfMovieSets / 100);
        }
    }
}