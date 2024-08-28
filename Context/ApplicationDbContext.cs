using Microsoft.EntityFrameworkCore;
using Stunt.Configurations;
using Stunt.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System;
namespace Stunt.Context;

public class ApplicationDbContext : DbContext
{

    public DbSet<Stuntman> Stuntmen { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<ExamTraining> ExamTrainings { get; set; }
    public DbSet<GroupTraining> GroupTrainings { get; set; }
    public DbSet<Horse> Horses { get; set; }
    public DbSet<MovieHorse> MovieHorses { get; set; }
    public DbSet<MovieStuntman> MovieStuntmans { get; set; }
    public DbSet<StuntLeader> StuntLeaders { get; set; }
    public DbSet<TrainingTypeMapping> TrainingTypeMappings { get; set; }
    public DbSet<MovieSet> MovieSets { get; set; }

    public DbSet<Owner> Owners { get; set; }


    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .ToTable("People");

        modelBuilder.Entity<Stuntman>()
            .ToTable("Stuntmen");

        modelBuilder.Entity<StuntLeader>()
            .ToTable("StuntLeaders");

        modelBuilder.ApplyConfiguration(new PersonConfiguration());

        modelBuilder.Entity<Training>().ToTable("Trainings");
        modelBuilder.Entity<GroupTraining>().ToTable("GroupTrainings");
        modelBuilder.Entity<ExamTraining>().ToTable("ExamTrainings");

        modelBuilder.Entity<Training>()
            .HasOne(t => t.Location)
            .WithMany(l => l.Trainings)
            .HasForeignKey(l => l.IdLocation);

        modelBuilder.Entity<Training>()
            .HasIndex(t => new { t.IdLocation, t.DateTime })
            .IsUnique();

        modelBuilder.Entity<Location>()
            .HasIndex(l => l.Name)
            .IsUnique();

        //TYP TRENINGU 
        modelBuilder.Entity<TrainingTypeMapping>()
            .HasKey(t => new { t.TrainingId, t.TrainingType });  // Composite key

        modelBuilder.Entity<TrainingTypeMapping>()
            .HasOne(tm => tm.Training)
            .WithMany(t => t.TrainingTypes)
            .HasForeignKey(tm => tm.TrainingId);

        modelBuilder.Entity<TrainingTypeMapping>()
            .Property(tm => tm.TrainingType)
            .HasConversion<string>();

        modelBuilder.Entity<Horse>()
            .HasMany(s => s.Trainings)
            .WithMany(t => t.Horses);

        modelBuilder.Entity<Stuntman>()
            .HasMany(s => s.Trainings)
            .WithMany(t => t.Stuntmans);


        modelBuilder.Entity<StuntLeader>()
            .HasMany(sl => sl.ConductedTrainings) // Treningi prowadzone przez StuntmanLeader
            .WithOne(t => t.StuntLeader) // Lider treningu
            .HasForeignKey(t => t.IdStuntLeader);



        //Movie - Stuntman
        modelBuilder.Entity<MovieStuntman>()
            .HasKey(ms => new { ms.IdMovieSet, ms.IdPerson });

        modelBuilder.Entity<MovieStuntman>()
            .HasOne(h => h.Stuntman)
            .WithMany(mh => mh.MovieSets)
            .HasForeignKey(m => m.IdPerson);

        modelBuilder.Entity<MovieStuntman>()
            .HasOne(m => m.MovieSet)
            .WithMany(mh => mh.Stuntmans)
            .HasForeignKey(m => m.IdMovieSet);


        //Połączenie w - w Movie - Horse
        modelBuilder.Entity<MovieHorse>()
            .HasKey(mh => new { mh.IdMovieSet, mh.IdHorse });

        modelBuilder.Entity<MovieHorse>()
            .HasOne(h => h.Horse)
            .WithMany(mh => mh.Movies)
            .HasForeignKey(m => m.IdHorse);

        modelBuilder.Entity<MovieHorse>()
            .HasOne(m => m.MovieSet)
            .WithMany(mh => mh.Horses)
            .HasForeignKey(m => m.IdMovieSet);
    }

}
