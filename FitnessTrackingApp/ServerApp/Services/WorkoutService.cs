using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly WorkoutContext _context;

        public WorkoutService(WorkoutContext context)
        {
            _context = context;
        }
        [EnableCors("corsapp")]
        public async Task<List<Workout>> GetAllWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }
        [EnableCors("corsapp")]
        public async Task<Workout?> GetWorkoutById(Guid id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
        }
        [EnableCors("corsapp")]
        public async Task<Workout> CreateWorkout(WorkoutPost workoutPost)
        {
            Workout workout = new Workout(workoutPost);
            workout.Version = Guid.NewGuid();
            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();
            return workout;
        }
        [EnableCors("corsapp")]
        public async Task<Workout> AddUserExercise(Guid workoutId, UserExerciseAddPost userExerciseAddPost)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == workoutId);
            if (workout != null)
            {
                var userExercise = await _context.UserExercises.FirstOrDefaultAsync(u => u.Id == userExerciseAddPost.UserExerciseId);
                if(userExercise != null)
                {
                    workout.UserExercises.Add(userExercise);
                    _context.Workouts.Update(workout);
                    await _context.SaveChangesAsync();
                    return workout;
                }
                else
                {
                    throw new NotFoundException();
                }
            }
            else
            {
                throw new NotFoundException();
            }
        }
        [EnableCors("corsapp")]
        public async Task DeleteWorkout(Guid id)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if(workout != null)
            {
                _context.Workouts.Remove(workout);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException();
            }
        }
        [EnableCors("corsapp")]
        public async Task<IEnumerable<UserExerciseGet>> GetUserExercisesForWorkout(Guid workoutId)
        {
            var workout = await _context.Workouts
                                        .Include(w => w.UserExercises)
                                        .FirstOrDefaultAsync(w => w.Id == workoutId);

            if (workout == null)
            {
                throw new KeyNotFoundException("Workout not found.");
            }

            var userExercises = workout.UserExercises.Select(ue => new UserExerciseGet
            {
                Id = ue.Id,
                ExerciseId = ue.ExerciseId,
                UserId = ue.UserId,
                MaxWeight = ue.MaxWeight,
                MaxReps = ue.MaxReps,
            }).ToList();

            return userExercises;
        }

        [EnableCors("corsapp")]
        public async Task<Workout?> UpdateWorkout(Guid id, WorkoutUpdate workoutUpdate)
        {
            var workout = await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
            if (workout == null)
            {
                return null;
            }

            workout.Name = workoutUpdate.Name;
            workout.Version = Guid.NewGuid(); // Update the version to ensure concurrency control

            await _context.SaveChangesAsync();
            return workout;
        }

        public async Task<List<Workout>> GetWorkoutsByUserId(Guid userId)
        {
            return await _context.Workouts
                                 .Where(w => w.UserId == userId)
                                 .ToListAsync();
        }

    }
}
