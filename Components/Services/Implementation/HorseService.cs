using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.Enum;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation
{
    public class HorseService : IHorseService
    {
        private readonly ApplicationDbContext _context;

        public HorseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HorseDto>> GetAllHorsesAsync()
        {
            var horses = await _context.Horses.ToListAsync();
            return horses.Select(HorseMapper.ToDTO).ToList();
        }
        
        public async Task<IEnumerable<HorseDto>> GetActiveHorsesAsync()
        {
            var horses = await _context.Horses.Where(h => h.Status == Status.Active).ToListAsync();
            return horses.Select(HorseMapper.ToDTO).ToList();
        }


        public async Task<HorseDto> GetHorseByIdAsync(int id)
        {
            var horse = await _context.Horses.FindAsync(id);
            if (horse == null)
            {
                return null;
            }
            return HorseMapper.ToDTO(horse);
        }

        public async Task<HorseDto> AddHorseAsync(HorseDto horseDto)
        {
            var horse = HorseMapper.ToEntity(horseDto);
            _context.Horses.Add(horse);
            await _context.SaveChangesAsync();
            return HorseMapper.ToDTO(horse);
        }

        public async Task<HorseDto> UpdateHorseAsync(HorseDto horseDto)
        {
            var horse = HorseMapper.ToEntity(horseDto);
            _context.Horses.Update(horse);
            await _context.SaveChangesAsync();
            return HorseMapper.ToDTO(horse);
        }

        public async Task<bool> DeleteHorseAsync(int id)
        {
            var horse = await _context.Horses.FindAsync(id);
            if (horse == null)
            {
                return false;
            }

            _context.Horses.Remove(horse);
            await _context.SaveChangesAsync();
            return true;
        }
        
        public async Task<IEnumerable<HorseDto>> GetAvailableHorsesAsync(DateTime date)
        {
            var horses = await _context.Horses
                .Include(h => h.Trainings)
                .Where(h => h.Trainings.All(t => t.DateTime != date))
                .ToListAsync();

            return horses.Select(HorseMapper.ToDTO);
        }
    }
}