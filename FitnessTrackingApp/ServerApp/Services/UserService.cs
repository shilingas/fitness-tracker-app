using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.EntityFrameworkCore;
using OpenQA.Selenium;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class UserService : IUserService
    {
        private readonly WorkoutContext _context;

        public UserService(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUser(UserPost userPost)
        {
            User user = new User(userPost);
            user.Version = Guid.NewGuid();
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(Guid id, UserUpdate userUpdate)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new NotFoundException();
            }

            existingUser.Name = userUpdate.Name ?? existingUser.Name;
            existingUser.Surname = userUpdate.Surname ?? existingUser.Surname;
            existingUser.PhoneNumber = userUpdate.PhoneNumber ?? existingUser.PhoneNumber;
            existingUser.Heigth = userUpdate.Heigth ?? existingUser.Heigth;
            existingUser.Weight = userUpdate.Weight ?? existingUser.Weight;
            existingUser.GoalWeight = userUpdate.GoalWeight ?? existingUser.GoalWeight;
            existingUser.Version = Guid.NewGuid();
            await _context.SaveChangesAsync();
            return existingUser;

        }

        public async Task DeleteUser(Guid id)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                //throw error
            }
        }
    }
}
