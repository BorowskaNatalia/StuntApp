using BlazorApp2;
using Microsoft.AspNetCore.Mvc;
using Stunt.Models;

namespace Stunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieStuntmanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieStuntmanController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieStuntman>>> GetMovieStuntmen()
        {
            return Ok(await _unitOfWork.MovieStuntmen.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieStuntman>> GetMovieStuntman(int id)
        {
            var movieStuntman = await _unitOfWork.MovieStuntmen.GetByIdAsync(id);

            if (movieStuntman == null)
            {
                return NotFound();
            }

            return Ok(movieStuntman);
        }

        [HttpPost]
        public async Task<ActionResult<MovieStuntman>> PostMovieStuntman(MovieStuntman movieStuntman)
        {
            await _unitOfWork.MovieStuntmen.AddAsync(movieStuntman);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetMovieStuntman", new { id = movieStuntman.MovieStuntmanId }, movieStuntman);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovieStuntman(int id, MovieStuntman movieStuntman)
        {
            if (id != movieStuntman.MovieStuntmanId)
            {
                return BadRequest();
            }

            await _unitOfWork.MovieStuntmen.UpdateAsync(movieStuntman);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovieStuntman(int id)
        {
            var movieStuntman = await _unitOfWork.MovieStuntmen.GetByIdAsync(id);
            if (movieStuntman == null)
            {
                return NotFound();
            }

            await _unitOfWork.MovieStuntmen.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
