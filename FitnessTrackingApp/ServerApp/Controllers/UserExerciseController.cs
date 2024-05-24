using FitnessTrackingApp.ServerApp.IServices;
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
    public class UserExcerciseController : ControllerBase
    {
        private readonly IUserExerciseService _userExerciseService;

        public UserExcerciseController(IUserExerciseService userExerciseService)
        {
            _userExerciseService = userExerciseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserExercises()
        {
            var userExercises = await _userExerciseService.GetAllUserExercises();
            return Ok(userExercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(Guid id)
        {
            try
            {
                var userExercise = await _userExerciseService.GetUserExerciseById(id);
                if (userExercise == null)
                {
                    return NotFound();
                }
                return Ok(userExercise);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving the user exercise.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserExercise([FromBody] UserExercisePost userExercisePost)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdUserExercise = await _userExerciseService.CreateUserExercise(userExercisePost);
                return Ok(createdUserExercise);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the user exercise.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserExercise(Guid id,[FromBody] UserExercisePut userExercisePut)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedUser = await _userExerciseService.UpdateUserExercise(id, userExercisePut);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while updating the user exercise.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(Guid id)
        {
            try
            {
                await _userExerciseService.DeleteUserExercise(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while deleting the user exercise.");
            }
        }

        [HttpPost("{userExerciseId}/workouts/{workoutId}")]
        public async Task<IActionResult> AddUserExerciseToWorkout(Guid userExerciseId, Guid workoutId)
        {
            try
            {
                var updatedUserExercise = await _userExerciseService.AddUserExerciseToWorkout(userExerciseId, workoutId);
                return Ok(updatedUserExercise);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while adding the user exercise to the workout.");
            }
        }
    }
}
