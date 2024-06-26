﻿using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.AspNetCore.Cors;
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
        [EnableCors("corsapp")]
        public async Task<List<UserExercise>> GetAllUserExercises()
        {
            return await _context.UserExercises.ToListAsync();
        }
        [EnableCors("corsapp")]
        public async Task<UserExercise?> GetUserExerciseById(Guid id)
        {
            return await _context.UserExercises.FirstOrDefaultAsync(ue => ue.Id == id);
        }
        [EnableCors("corsapp")]
        public async Task<UserExercise> CreateUserExercise(UserExercisePost userExercisePost)
        {
            UserExercise userExercise = new UserExercise(userExercisePost);
            userExercise.Version = Guid.NewGuid();
            _context.UserExercises.Add(userExercise);
            await _context.SaveChangesAsync();
            return userExercise;
        }
        [EnableCors("corsapp")]
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
            _context.UserExercises.Update(existingUserExercise);
            await _context.SaveChangesAsync();
            return existingUserExercise;
        }
        [EnableCors("corsapp")]
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
        [EnableCors("corsapp")]
        public async Task<UserExerciseDto> AddUserExerciseToWorkout(Guid userExerciseId, Guid workoutId)
        {
            var userExercise = await _context.UserExercises
                                             .Include(ue => ue.Workouts)
                                             .FirstOrDefaultAsync(ue => ue.Id == userExerciseId);
            if (userExercise == null)
            {
                throw new KeyNotFoundException("UserExercise not found.");
            }

            var workout = await _context.Workouts.FindAsync(workoutId);
            if (workout == null)
            {
                throw new KeyNotFoundException("Workout not found.");
            }

            userExercise.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            var dto = new UserExerciseDto
            {
                Id = userExercise.Id,
                ExerciseId = userExercise.ExerciseId,
                UserId = userExercise.UserId,
                WorkoutIds = userExercise.Workouts.Select(w => w.Id).ToList()
            };

            return dto;
        }
        [EnableCors("corsapp")]
        public async Task<List<UserExerciseDto>> AddAndCreateUserExercises(List<UserExercisePost> userExercisesPost, Guid workoutId)
        {
            var workout = await _context.Workouts.FindAsync(workoutId);
            if (workout == null)
            {
                throw new KeyNotFoundException("Workout not found.");
            }

            var userExerciseDtos = new List<UserExerciseDto>();

            foreach (var userExercisePost in userExercisesPost)
            {
                UserExercise userExercise = new UserExercise(userExercisePost)
                {
                    Version = Guid.NewGuid()
                };

                userExercise.Workouts = new List<Workout> { workout };

                _context.UserExercises.Add(userExercise);

                var dto = new UserExerciseDto
                {
                    Id = userExercise.Id,
                    ExerciseId = userExercise.ExerciseId,
                    UserId = userExercise.UserId,
                    WorkoutIds = new List<Guid> { workout.Id }
                };

                userExerciseDtos.Add(dto);
            }

            await _context.SaveChangesAsync();

            return userExerciseDtos;
        }
    }
}
