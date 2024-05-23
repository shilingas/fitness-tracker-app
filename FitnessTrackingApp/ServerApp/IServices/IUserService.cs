using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(Guid id);
        Task<User> CreateUser(UserPost userPost);
        Task<User> UpdateUser(Guid id, UserPut userUpdate);
        Task DeleteUser(Guid id);
    }
}
