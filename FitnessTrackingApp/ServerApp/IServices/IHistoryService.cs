using FitnessTrackingApp.ServerApp.Models;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IHistoryService
    {
        Task<List<History>> GetAllUserData(Guid id);
        Task<History> AddNewData(Guid id, decimal newWeight);
    }
}
