using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly WorkoutContext _context;

        public HistoryService(WorkoutContext context)
        {
            _context = context;
        }

        public async Task<List<History>> GetAllUserData(Guid id)
        {
            return await _context.History
                 .Where(h => h.UserId == id)
                 .ToListAsync();
        }

        public async Task<History> AddNewData(HistoryPost userPost)
        {
            History history = new History(userPost);
            _context.History.Add(history);
            await _context.SaveChangesAsync();
            return history;
        }
    }
}
