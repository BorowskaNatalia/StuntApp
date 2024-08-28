using Stunt.Context;
using Stunt.Models;
using Stunt.Repositories.Implementation;
using Stunt.Repositories.Interfaces;

namespace BlazorApp2
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Person> Persons { get; }
        IRepository<Stuntman> Stuntmen { get; }
        IRepository<Owner> Owners { get; }
        IRepository<StuntLeader> StuntLeaders { get; }
        IRepository<Training> Trainings { get; }
        IRepository<ExamTraining> IndividualTrainings { get; }
        IRepository<GroupTraining> GroupTrainings { get; }
        IRepository<Location> Locations { get; }
        IRepository<Horse> Horses { get; }
        IRepository<MovieSet> MovieSets { get; }
        IRepository<MovieStuntman> MovieStuntmen { get; }
        IRepository<MovieHorse> MovieHorses { get; }
       
        Task<int> SaveChangesAsync();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<Person> _persons;
        private IRepository<Stuntman> _stuntmen;
        private IRepository<Owner> _owners;
        private IRepository<StuntLeader> _stuntLeaders;
        private IRepository<Training> _trainings;
        private IRepository<ExamTraining> _individualTrainings;
        private IRepository<GroupTraining> _groupTrainings;
        private IRepository<Location> _locations;
        private IRepository<Horse> _horses;
        private IRepository<MovieSet> _movieSets;
        private IRepository<MovieStuntman> _movieStuntmen;
        private IRepository<MovieHorse> _movieHorses;
       

        public UnitOfWork(ApplicationDbContext context, IRepository<Person> persons, IRepository<Stuntman> stuntmen, IRepository<Owner> owners, IRepository<StuntLeader> stuntLeaders, IRepository<Training> trainings, IRepository<ExamTraining> individualTrainings, IRepository<GroupTraining> groupTrainings, IRepository<Location> locations, IRepository<Horse> horses, IRepository<MovieSet> movieSets, IRepository<MovieStuntman> movieStuntmen, IRepository<MovieHorse> movieHorses)
        {
            _context = context;
            _persons = persons;
            _stuntmen = stuntmen;
            _owners = owners;
            _stuntLeaders = stuntLeaders;
            _trainings = trainings;
            _individualTrainings = individualTrainings;
            _groupTrainings = groupTrainings;
            _locations = locations;
            _horses = horses;
            _movieSets = movieSets;
            _movieStuntmen = movieStuntmen;
            _movieHorses = movieHorses;
        }

        public IRepository<Person> Persons => _persons ??= new GenericRepository<Person>(_context);
        public IRepository<Stuntman> Stuntmen => _stuntmen ??= new GenericRepository<Stuntman>(_context);
        public IRepository<Owner> Owners => _owners ??= new GenericRepository<Owner>(_context);
        public IRepository<StuntLeader> StuntLeaders => _stuntLeaders ??= new GenericRepository<StuntLeader>(_context);
        public IRepository<Training> Trainings => _trainings ??= new GenericRepository<Training>(_context);
        public IRepository<ExamTraining> IndividualTrainings => _individualTrainings ??= new GenericRepository<ExamTraining>(_context);
        public IRepository<GroupTraining> GroupTrainings => _groupTrainings ??= new GenericRepository<GroupTraining>(_context);
        public IRepository<Location> Locations => _locations ??= new GenericRepository<Location>(_context);
        public IRepository<Horse> Horses => _horses ??= new GenericRepository<Horse>(_context);
        public IRepository<MovieSet> MovieSets => _movieSets ??= new GenericRepository<MovieSet>(_context);
        public IRepository<MovieStuntman> MovieStuntmen => _movieStuntmen ??= new GenericRepository<MovieStuntman>(_context);
        public IRepository<MovieHorse> MovieHorses => _movieHorses ??= new GenericRepository<MovieHorse>(_context);
      

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
