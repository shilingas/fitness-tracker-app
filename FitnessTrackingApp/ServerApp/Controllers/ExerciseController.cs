using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.ServerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExercises()
        {
            var exercises = await _exerciseService.GetAllExercises();
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise(Guid id)
        {
            try
            {
                var exercise = await _exerciseService.GetExerciseById(id);
                if (exercise == null)
                {
                    return NotFound();
                }
                return Ok(exercise);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving the exercise.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddExercise([FromBody] ExercisePost exercisePost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdExercise = await _exerciseService.AddExercise(exercisePost);
                return CreatedAtAction(nameof(GetExercise), new { id = createdExercise.Id }, createdExercise);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the exercise.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            try
            {
                await _exerciseService.DeleteExercise(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting the exercise.");
            }
        }
    }
}
