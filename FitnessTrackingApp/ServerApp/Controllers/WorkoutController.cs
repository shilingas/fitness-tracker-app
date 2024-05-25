using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using FitnessTrackingApp.ServerApp.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTrackingApp.ServerApp.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    [EnableCors("corsapp")]
    public class WorkoutController : ControllerBase
    {
        private readonly IWorkoutService _workoutService;

        public WorkoutController(IWorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkouts()
        {
            var workouts = await _workoutService.GetAllWorkouts();
            return Ok(workouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout(Guid id)
        {
            try
            {
                var workout = await _workoutService.GetWorkoutById(id);
                if (workout == null)
                {
                    return NotFound();
                }
                return Ok(workout);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving the workout.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkout([FromBody] WorkoutPost workoutPost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdWorkout = await _workoutService.CreateWorkout(workoutPost);
                return Ok(createdWorkout);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the workout.");
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> AddUserExercise(Guid id, [FromBody] UserExerciseAddPost userExerciseAddPost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedWorkout = await _workoutService.AddUserExercise(id, userExerciseAddPost);
                return Ok(updatedWorkout);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the workout.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout(Guid id)
        {
            try
            {
                await _workoutService.DeleteWorkout(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting the workout.");
            }
        }

        [HttpGet("{workoutId}/user-exercises")]
        public async Task<ActionResult<IEnumerable<UserExerciseDto>>> GetWorkoutUserExercises(Guid workoutId)
        {
            try
            {
                var userExercises = await _workoutService.GetUserExercisesForWorkout(workoutId);
                return Ok(userExercises);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}/user-workouts")]
        public async Task<ActionResult<List<Workout>>> GetWorkoutsByUserId(Guid userId)
        {
            try
            {
                var workouts = await _workoutService.GetWorkoutsByUserId(userId);
                if (workouts == null || workouts.Count == 0)
                {
                    return NotFound();
                }
                return Ok(workouts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
