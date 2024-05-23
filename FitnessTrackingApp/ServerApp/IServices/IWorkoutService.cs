using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IWorkoutService
    {
        Task<List<Workout>> GetAllWorkouts();
        Task<Workout?> GetWorkoutById(Guid id);
        Task<Workout> CreateWorkout(WorkoutPost workoutPost);
        Task<Workout> AddUserExercise(Guid workoutId, UserExerciseAddPost userExerciseAddPost);
        Task DeleteWorkout(Guid id);
    }
}
