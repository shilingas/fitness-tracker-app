using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.Decorators
{
    public abstract class UserExerciseDecorator : IUserExerciseService
    {
        protected readonly IUserExerciseService _decoratedService;

        public UserExerciseDecorator(IUserExerciseService decoratedService)
        {
            _decoratedService = decoratedService;
        }

        public virtual Task<List<UserExerciseDto>> AddAndCreateUserExercises(List<UserExercisePost> userExercisesPost, Guid workoutId)
        {
            return _decoratedService.AddAndCreateUserExercises(userExercisesPost, workoutId);
        }

        public virtual Task<UserExerciseDto> AddUserExerciseToWorkout(Guid userExerciseId, Guid workoutId)
        {
            return _decoratedService.AddUserExerciseToWorkout(userExerciseId, workoutId);
        }

        public virtual Task<UserExercise> CreateUserExercise(UserExercisePost userExercisePost)
        {
            return _decoratedService.CreateUserExercise(userExercisePost);
        }

        public virtual Task DeleteUserExercise(Guid id)
        {
            return _decoratedService.DeleteUserExercise(id);
        }

        public virtual Task<List<UserExercise>> GetAllUserExercises()
        {
            return _decoratedService.GetAllUserExercises();
        }

        public virtual Task<UserExercise?> GetUserExerciseById(Guid id)
        {
            return _decoratedService.GetUserExerciseById(id);
        }

        public virtual Task<UserExercise> UpdateUserExercise(Guid id, UserExercisePut userExercisePut)
        {
            return _decoratedService.UpdateUserExercise(id, userExercisePut);
        }
    }
}
