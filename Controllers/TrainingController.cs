using BlazorApp2;
using Microsoft.AspNetCore.Mvc;
using Stunt.Models;

namespace Stunt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Training>>> GetTrainings()
        {
            return Ok(await _unitOfWork.Trainings.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Training>> GetTraining(int id)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(id);

            if (training == null)
            {
                return NotFound();
            }

            return Ok(training);
        }

        [HttpPost]
        public async Task<ActionResult<Training>> PostTraining(Training training)
        {
            await _unitOfWork.Trainings.AddAsync(training);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetTraining", new { id = training.IdTraining }, training);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTraining(int id, Training training)
        {
            if (id != training.IdTraining)
            {
                return BadRequest();
            }

            await _unitOfWork.Trainings.UpdateAsync(training);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTraining(int id)
        {
            var training = await _unitOfWork.Trainings.GetByIdAsync(id);
            if (training == null)
            {
                return NotFound();
            }

            await _unitOfWork.Trainings.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
