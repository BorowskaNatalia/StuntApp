
using Microsoft.EntityFrameworkCore;
using Stunt.Context;
using Stunt.Enum;
using Stunt.Models;
using Stunt.ModelsDto;
using Stunt.Repositories.Interfaces;

namespace Stunt.Repositories.Implementation;


public class StuntmanRepository : IStuntmanRepository
{ 
    public ApplicationDbContext _context;
    public StuntmanRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<dynamic> GetAllStuntmenAsync()
    {
        var res = await _context.Stuntmen.Where(s => s.Rank == Rank.Stuntman).ToListAsync();
        return  res;
    }
    public async Task<dynamic> GetAllCadetsAsync()
    {
        var res = await _context.Stuntmen.Where(s => s.Rank == Rank.Cadet).ToListAsync();
        return  res;
    }
    public async Task<dynamic> GetStuntmanByIdAsync(int id)
    {
        var res = await _context.Stuntmen.Where(s => s.Rank == Rank.Stuntman).FirstOrDefaultAsync(s => s.IdPerson == id);
        return res;
    }
    public async Task<dynamic> GetCadetByIdAsync(int id)
    {
        var res = await _context.Stuntmen.Where(s => s.Rank == Rank.Cadet).FirstOrDefaultAsync(s => s.IdPerson == id);
        return res;
    }
    public async Task<StatusEnum> AddStuntmanAsync(StuntmanDto stuntmanDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            var doesStuntmanExist = await _context.Stuntmen.FirstOrDefaultAsync(s => s.Alias == stuntmanDto.Alias);
            if (doesStuntmanExist == null)
            {
                await _context.Stuntmen.AddAsync(new Stuntman
                {
                    Name = stuntmanDto.Name,
                    Surname = stuntmanDto.Surname,
                    Birthdate = stuntmanDto.Birthdate,
                    Alias = stuntmanDto.Alias,
                    JoiningDate = stuntmanDto.JoiningDate,
                    Salary = stuntmanDto.Salary,
                    Rank = Rank.Stuntman

                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return StatusEnum.Success;
            }

            return StatusEnum.AliasStuntmanIsNotUnique;
        }
    }
    public async Task<StatusEnum> AddCadetAsync(CadetDto cadetDto)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
                await _context.Stuntmen.AddAsync(new Stuntman
                {
                    Name = cadetDto.Name,
                    Surname = cadetDto.Surname,
                    Birthdate = cadetDto.Birthdate,
                    JoiningDate = cadetDto.JoiningDate,
                    Salary = cadetDto.Salary,
                    Rank = Rank.Cadet

                });
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return StatusEnum.Success;
        }
    }
    
    
}