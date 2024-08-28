using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stunt.Models;

namespace Stunt.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.IdPerson);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Surname)
            .IsRequired() 
            .HasMaxLength(100); 

        builder.Property(p => p.Birthdate)
            .IsRequired(); 

        builder.Property(p => p.Alias)
            .IsRequired(false); 

        builder.Property(p => p.JoiningDate)
            .IsRequired();

        builder.Property(p => p.Salary)
            .HasColumnType("decimal(18,2)"); 
    }
}