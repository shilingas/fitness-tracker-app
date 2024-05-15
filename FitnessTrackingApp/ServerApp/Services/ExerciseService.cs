using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly WorkoutContext _context;

        public ExerciseService(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<List<Exercise>> GetAllExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise?> GetExerciseById(Guid id)
        {
            return await _context.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
        }

        public async Task<Exercise> AddExercise(ExercisePost exercisePost)
        {
            Exercise exercise = new Exercise(exercisePost);
            exercise.Version = Guid.NewGuid();
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task DeleteExercise(Guid id)
        {
            Exercise? exercise = await _context.Exercises.FirstOrDefaultAsync(ex => ex.Id == id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
            else
            {
                //throw error
            }
        }
    }
}
