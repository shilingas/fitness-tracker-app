using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IHistoryService
    {
        Task<List<History>> GetAllUserData(Guid id);
        Task<History> AddNewData(HistoryPost historyPost);
    }
}
