using Microsoft.EntityFrameworkCore;
using Stunt.Components.Services.Interfaces;
using Stunt.Context;
using Stunt.Enum;
using Stunt.ModelsDto;
using Stunt.ModelsDto.Mappers;

namespace Stunt.Components.Services.Implementation;

public class StuntmanService : IStuntmanService
{
    private readonly ApplicationDbContext _context;

    public StuntmanService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<StuntmanDto>> GetAllStuntmenAsync()
    {
        var stuntmen = await _context.Stuntmen.ToListAsync();
        return stuntmen.Select(StuntmanMapper.ToDTO).ToList();
    }

    public async Task<StuntmanDto> GetStuntmanByIdAsync(int id)
    {
        var stuntman = await _context.Stuntmen.FindAsync(id);
        if (stuntman == null)
        {
            return null;
        }

        return StuntmanMapper.ToDTO(stuntman);
    }

    public async Task<StuntmanDto> AddStuntmanAsync(StuntmanDto stuntmanDto)
    {
        var stuntman = StuntmanMapper.ToEntity(stuntmanDto);
        _context.Stuntmen.Add(stuntman);
        await _context.SaveChangesAsync();
        return StuntmanMapper.ToDTO(stuntman);
    }

    public async Task<StuntmanDto> UpdateStuntmanAsync(StuntmanDto stuntmanDto)
    {
        var stuntman = StuntmanMapper.ToEntity(stuntmanDto);
        _context.Stuntmen.Update(stuntman);
        await _context.SaveChangesAsync();
        return StuntmanMapper.ToDTO(stuntman);
    }

    public async Task<bool> DeleteStuntmanAsync(int id)
    {
        var stuntman = await _context.Stuntmen.FindAsync(id);
        if (stuntman == null)
        {
            return false;
        }

        _context.Stuntmen.Remove(stuntman);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> AliasExistsAsync(string alias)
    {
        var existingStuntman = await _context.Stuntmen.AnyAsync(s => s.Alias == alias);
        return existingStuntman;
    }

    public async Task UpdateSalaryAsync(int id, double newSalary)
    {
        var stuntman = await _context.Stuntmen.FindAsync(id);
        if (stuntman != null)
        {
            stuntman.Salary = newSalary;
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task PromoteStuntmanAsync(int stuntmanId, string alias)
    {
        var stuntman = await _context.Stuntmen.FindAsync(stuntmanId);
        if (stuntman == null)
        {
            throw new InvalidOperationException("Stuntman not found.");
        }

        if (stuntman.Birthdate.AddYears(18) > DateTime.Now)
        {
            throw new InvalidOperationException("Stuntman must be at least 18 years old to be promoted.");
        }

        var aliasExists = await _context.Stuntmen.AnyAsync(s => s.Alias == alias);
        if (aliasExists)
        {
            throw new InvalidOperationException("Alias must be unique. The provided alias is already in use.");
        }

        stuntman.Rank = Rank.Stuntman;
        stuntman.Alias = alias;
        await _context.SaveChangesAsync();
    }
}