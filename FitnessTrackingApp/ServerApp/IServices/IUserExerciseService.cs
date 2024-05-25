using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IUserExerciseService
    {
        Task<List<UserExercise>> GetAllUserExercises();
        Task<UserExercise?> GetUserExerciseById(Guid id);
        Task<UserExercise> CreateUserExercise(UserExercisePost userExercisePost);
        Task<UserExercise> UpdateUserExercise(Guid id, UserExercisePut userExercisePut);
        Task DeleteUserExercise(Guid id);
        Task<UserExerciseDto> AddUserExerciseToWorkout(Guid userExerciseId, Guid workoutId);
    }
}
