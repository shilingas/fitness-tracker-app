using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IExerciseService
    {
        Task<List<Exercise>> GetAllExercises();
        Task<Exercise?> GetExerciseById(Guid id);
        Task<Exercise> AddExercise(ExercisePost exercisePost);
        Task DeleteExercise(Guid id);
    }
}
