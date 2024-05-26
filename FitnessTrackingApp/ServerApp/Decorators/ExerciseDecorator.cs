using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.Decorators
{
    public class ExerciseDecorator : IExerciseService
    {
        private readonly IExerciseService _decoratedService;

        public ExerciseDecorator(IExerciseService exerciseService)
        {
            _decoratedService = exerciseService;
        }

        public virtual Task<Exercise> CreateExercise(ExercisePost exercisePost)
        {
            return _decoratedService.CreateExercise(exercisePost);
        }

        public virtual Task DeleteExercise(Guid id)
        {
            return _decoratedService.DeleteExercise(id);
        }

        public virtual Task<List<Exercise>> GetAllExercises()
        {
            return _decoratedService.GetAllExercises();
        }

        public virtual Task<Exercise?> GetExerciseById(Guid id)
        {
            return _decoratedService.GetExerciseById(id);
        }

        public Task<Exercise?> UpdateExercise(Guid id, ExercisePost exercisePost)
        {
            throw new NotImplementedException();
        }
    }
}
