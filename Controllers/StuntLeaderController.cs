using BlazorApp2;
using Microsoft.AspNetCore.Mvc;
using Stunt.Models;

namespace Stunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuntLeaderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StuntLeaderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StuntLeader>>> GetStuntLeaders()
        {
            return Ok(await _unitOfWork.StuntLeaders.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StuntLeader>> GetStuntLeader(int id)
        {
            var stuntLeader = await _unitOfWork.StuntLeaders.GetByIdAsync(id);

            if (stuntLeader == null)
            {
                return NotFound();
            }

            return Ok(stuntLeader);
        }

        [HttpPost]
        public async Task<ActionResult<StuntLeader>> PostStuntLeader(StuntLeader stuntLeader)
        {
            await _unitOfWork.StuntLeaders.AddAsync(stuntLeader);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetStuntLeader", new { id = stuntLeader.IdPerson }, stuntLeader);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStuntLeader(int id, StuntLeader stuntLeader)
        {
            if (id != stuntLeader.IdPerson)
            {
                return BadRequest();
            }

            await _unitOfWork.StuntLeaders.UpdateAsync(stuntLeader);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuntLeader(int id)
        {
            var stuntLeader = await _unitOfWork.StuntLeaders.GetByIdAsync(id);
            if (stuntLeader == null)
            {
                return NotFound();
            }

            await _unitOfWork.StuntLeaders.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
