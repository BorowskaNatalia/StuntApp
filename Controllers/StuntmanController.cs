using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stunt.Context;
using Stunt.Enum;
using Stunt.ModelsDto;
using Stunt.Repositories.Interfaces;

namespace Stunt.Controllers;

[ApiController]
[Route("[controller]")]
public class StuntmenController : ControllerBase
{
    private readonly IStuntmanRepository _repository;

    public StuntmenController(IStuntmanRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("stuntmans")]
    public async Task<IActionResult> GetAllStuntmen()
    {
        var res = await _repository.GetAllStuntmenAsync();
        return Ok(res);
    }
    
    [HttpGet("stuntmans/{id}")]
    public async Task<IActionResult> GetStuntmanById(int id)
    {
        var stuntman = await _repository.GetStuntmanByIdAsync(id);
        if (stuntman == null)
        {
            return NotFound();
        }
        return Ok(stuntman);
    }
    
    [HttpGet("cadets/{id}")]
    public async Task<IActionResult> GetCadetById(int id)
    {
        var stuntman = await _repository.GetCadetByIdAsync(id);
        if (stuntman == null)
        {
            return NotFound();
        }
        return Ok(stuntman);
    }
    
    [HttpGet("cadets")]
    public async Task<IActionResult> GetAllCadets()
    {
        var res = await _repository.GetAllCadetsAsync();
        return Ok(res);
    }

    [HttpPost("AddStuntman")]
    public async Task<IActionResult> AddStuntman(StuntmanDto stuntmanDto)
    {
        var result = await _repository.AddStuntmanAsync(stuntmanDto);
        switch (result)
        {
            case StatusEnum.AliasStuntmanIsNotUnique: return Conflict("Alias nie jest unikalny");
            default: return Ok("Stworzono stuntmana");
        }
    }
    
    [HttpPost("AddCadet")]
    public async Task<IActionResult> AddCadet(CadetDto cadetDto)
    {
        var result = await _repository.AddCadetAsync(cadetDto);
        switch (result)
        {
            default: return Ok("Stworzono cadeta");
        }
    }
}