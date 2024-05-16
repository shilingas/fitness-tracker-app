using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class UserExerciseService : IUserExerciseService
    {
        private readonly WorkoutContext _context;

        public UserExerciseService(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<List<UserExercise>> GetAllUserExercises()
        {
            return await _context.UserExercises.ToListAsync();
        }

        public async Task<UserExercise?> GetUserExerciseById(Guid id)
        {
            return await _context.UserExercises.FirstOrDefaultAsync(ue => ue.Id == id);
        }

        public async Task<UserExercise> CreateUserExercise(UserExercisePost userExercisePost)
        {
            UserExercise userExercise = new UserExercise(userExercisePost);
            userExercise.Version = Guid.NewGuid();
            await _context.SaveChangesAsync();
            return userExercise;
        }

        public async Task<UserExercise> UpdateUserExercise(Guid id, UserExercisePut userExercisePut)
        {
            var existingUserExercise = await _context.UserExercises.FindAsync(id);
            if (existingUserExercise == null)
            {
                throw new NotFoundException();
            }

            existingUserExercise.MaxWeight = userExercisePut.MaxWeight ?? existingUserExercise.MaxWeight;
            existingUserExercise.MaxReps = userExercisePut.MaxReps ?? existingUserExercise.MaxReps;
            existingUserExercise.Version = Guid.NewGuid();
            await _context.SaveChangesAsync();
            return existingUserExercise;
        }

        public async Task DeleteUserExercise(Guid id)
        {
            UserExercise? userExercise = await _context.UserExercises.FirstOrDefaultAsync(ue => ue.Id == id);
            if (userExercise != null)
            {
                _context.UserExercises.Remove(userExercise);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException();
            }

        }
    }
}
