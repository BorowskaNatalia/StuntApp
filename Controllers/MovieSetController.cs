using BlazorApp2;
using Microsoft.AspNetCore.Mvc;
using Stunt.Models;

namespace Stunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieSetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieSetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieSet>>> GetMovieSets()
        {
            return Ok(await _unitOfWork.MovieSets.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieSet>> GetMovieSet(int id)
        {
            var movieSet = await _unitOfWork.MovieSets.GetByIdAsync(id);

            if (movieSet == null)
            {
                return NotFound();
            }

            return Ok(movieSet);
        }

        [HttpPost]
        public async Task<ActionResult<MovieSet>> PostMovieSet(MovieSet movieSet)
        {
            await _unitOfWork.MovieSets.AddAsync(movieSet);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMovieSet", new { id = movieSet.IdMovieSet }, movieSet);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieSet(int id, MovieSet movieSet)
        {
            if (id != movieSet.IdMovieSet)
            {
                return BadRequest();
            }

            await _unitOfWork.MovieSets.UpdateAsync(movieSet);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieSet(int id)
        {
            var movieSet = await _unitOfWork.MovieSets.GetByIdAsync(id);
            if (movieSet == null)
            {
                return NotFound();
            }

            await _unitOfWork.MovieSets.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
