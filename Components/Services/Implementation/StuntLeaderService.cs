using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation
{
    public class StuntLeaderService : IStuntLeaderService
    {
        private readonly ApplicationDbContext _context;

        public StuntLeaderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StuntLeaderDto>> GetAllStuntLeadersAsync()
        {
            var stuntLeaders = await _context.StuntLeaders.ToListAsync();
            return stuntLeaders.Select(StuntLeaderMapper.ToDTO).ToList();
        }

        public async Task<StuntLeaderDto> GetStuntLeaderByIdAsync(int id)
        {
            var stuntLeader = await _context.StuntLeaders.FindAsync(id);
            return stuntLeader == null ? null : StuntLeaderMapper.ToDTO(stuntLeader);
        }

        public async Task<StuntLeaderDto> AddStuntLeaderAsync(StuntLeaderDto stuntLeaderDto)
        {
            var stuntLeader = StuntLeaderMapper.ToEntity(stuntLeaderDto);
            _context.StuntLeaders.Add(stuntLeader);
            await _context.SaveChangesAsync();
            return StuntLeaderMapper.ToDTO(stuntLeader);
        }

        public async Task<StuntLeaderDto> UpdateStuntLeaderAsync(StuntLeaderDto stuntLeaderDto)
        {
            var stuntLeader = StuntLeaderMapper.ToEntity(stuntLeaderDto);
            _context.StuntLeaders.Update(stuntLeader);
            await _context.SaveChangesAsync();
            return StuntLeaderMapper.ToDTO(stuntLeader);
        }

        public async Task<bool> DeleteStuntLeaderAsync(int id)
        {
            var stuntLeader = await _context.StuntLeaders.FindAsync(id);
            if (stuntLeader == null)
            {
                return false;
            }

            _context.StuntLeaders.Remove(stuntLeader);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
