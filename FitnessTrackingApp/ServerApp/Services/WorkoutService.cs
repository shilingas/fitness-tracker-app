using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class WorkoutService : IWorkoutExercise
    {
        private readonly WorkoutContext _context;

        public WorkoutService(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<List<Workout>> GetAllWorkouts()
        {
            return await _context.Workouts.ToListAsync();
        }

        public async Task<Workout?> GetWorkoutById(Guid id)
        {
            return await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Workout> CreateWorkout(WorkoutPost workoutPost)
        {
            Workout workout = new Workout(workoutPost);
            workout.Version = Guid.NewGuid();
        }
        
    }
}
