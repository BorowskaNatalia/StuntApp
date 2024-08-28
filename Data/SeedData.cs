using Stunt.Context;
using Stunt.Enum;
using Stunt.Models;

namespace Stunt.Data
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext db)
        {
            var m = new MovieSet()
            {
                Title = "Czerowne maki",
                Budget = 100000,
                Address = "Nociskiego 7",
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2024, 3, 25)
            };
                
            var m2 = new MovieSet()
            {
                Title = "Miasto 44",
                Budget = 500000,
                Address = "Nociskiego 4",
                StartDate = new DateTime(2019, 01, 01),
                EndDate = new DateTime(2020, 9, 20)
            };
            
            var m3 = new MovieSet()
            {
                Title = "Akademia Pana Kleksa",
                Budget = 2000000,
                Address = "Nociskiego 1",
                StartDate = new DateTime(2023, 10, 12),
                EndDate = new DateTime(2024, 2, 23)
            };


            var s1 = new Stuntman()
            {
                Name = "Jan",
                Surname = "Mazurek",
                Alias = "Janko",
                Birthdate = new DateTime(2009, 10, 23),
                JoiningDate = new DateTime(2023, 4, 3),
                Rank = Rank.Stuntman,
                Salary = 6000
            };
            
            var s2 = new Stuntman()
            {
                Name = "Róża",
                Surname = "Kaszynska",
                Alias = "Róża",
                Birthdate = new DateTime(2007, 2, 23),
                JoiningDate = new DateTime(2022, 5, 3),
                Rank = Rank.Stuntman,
                Salary = 7000
            };
            
            var s3= new StuntLeader()
            {
                Name = "Hubert",
                Surname = "Zakrzewa",
                Alias = "Hubson",
                Birthdate = new DateTime(1983, 5, 3),
                JoiningDate = new DateTime(2000, 7, 8),
                Salary = 10000
            };
            
            var s4= new Stuntman()
            {
                Name = "Natalia",
                Surname = "Kyrys",
                Alias = "Kyrys",
                Birthdate = new DateTime(1999, 3, 3),
                JoiningDate = new DateTime(2017, 7, 18),
                Rank = Rank.Stuntman,
                Salary = 9000
            };

            var h1 = new Horse()
            {
                Name = "Max",
                Birthdate = new DateTime(1994, 4, 15),
                Status = Status.Active,
                isAvailable = true
            };
            
            var h2 = new Horse()
            {
                Name = "Matrix",
                Birthdate = new DateTime(1995, 6, 25),
                Status = Status.Active,
                isAvailable = true
            };
            
            var h3 = new Horse()
            {
                Name = "Apollo",
                Birthdate = new DateTime(2022, 3, 25),
                Status = Status.InTraining,
                isAvailable = true
            };
            
            var h4 = new Horse()
            {
                Name = "Gothic",
                Birthdate = new DateTime(1999, 4, 15),
                Status = Status.Active,
                isAvailable = true
            };
            
            var h5 = new Horse()
            {
                Name = "Thunder",
                Birthdate = new DateTime(2007, 7, 27),
                Status = Status.Active,
                isAvailable = true
            };
            
            var o1 = new Owner()
            {
                Name = "Natalia",
                Surname = "Borowska",
                Birthdate = new DateTime(2000, 4, 15),
                Alias = "Hvmak",
                JoiningDate = new DateTime(2022, 2, 23),
                Salary = 20000
            };
            
            db.MovieSets.Add(m);
            db.MovieSets.Add(m2);
            db.MovieSets.Add(m3);
            
            db.Stuntmen.Add(s1);
            db.Stuntmen.Add(s2);
            db.Stuntmen.Add(s4);

            db.StuntLeaders.Add(s3);

            db.Horses.Add(h1);
            db.Horses.Add(h2);
            db.Horses.Add(h3);
            db.Horses.Add(h4);
            db.Horses.Add(h5);

            db.Owners.Add(o1);
           
            
            
            db.SaveChanges();
        }
    }
}
