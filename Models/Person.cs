using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Stunt.Models;

public abstract class Person
{
    [Key] public int IdPerson { get; set; }
    [Required] public string Name { get;  set; }

    [Required] public string Surname { get; set; } 
    public DateTime Birthdate { get; set; }
    [AllowNull] public string Alias { get;  set; }
    public DateTime JoiningDate { get; set; }
    public double Salary { get;  set; }
    protected abstract double Earnings();
}