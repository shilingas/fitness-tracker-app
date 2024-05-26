using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class HistoryService : IHistory
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

        public async Task<History> AddNewData(Guid id, decimal newWeight)
        {
            History history = new History(id, newWeight);
            _context.History.Add(history);
            await _context.SaveChangesAsync();
            return history;
        }
    }
}
