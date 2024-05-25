using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.Decorators
{
    public abstract class WorkoutServiceDecorator : IWorkoutService
    {
        protected readonly IWorkoutService _decoratedService;

        protected WorkoutServiceDecorator(IWorkoutService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public virtual Task<Workout> AddUserExercise(Guid workoutId, UserExerciseAddPost userExerciseAddPost)
        {
            return _decoratedService.AddUserExercise(workoutId, userExerciseAddPost);
        }

        public virtual Task<Workout> CreateWorkout(WorkoutPost workoutPost)
        {
            return _decoratedService.CreateWorkout(workoutPost);
        }

        public virtual Task DeleteWorkout(Guid id)
        {
            return _decoratedService.DeleteWorkout(id);
        }

        public virtual Task<List<Workout>> GetAllWorkouts()
        {
            return _decoratedService.GetAllWorkouts();
        }

        public virtual Task<IEnumerable<UserExerciseGet>> GetUserExercisesForWorkout(Guid workoutId)
        {
            return _decoratedService.GetUserExercisesForWorkout(workoutId);
        }

        public virtual Task<Workout?> GetWorkoutById(Guid id)
        {
            return _decoratedService.GetWorkoutById(id);
        }

        public virtual Task<List<Workout>> GetWorkoutsByUserId(Guid userId)
        {
            return _decoratedService.GetWorkoutsByUserId(userId);
        }
    }
}
