using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;
using FitnessTrackingApp.ServerApp.Other.Dto;

namespace FitnessTrackingApp.ServerApp.Decorators
{
    public abstract class UserDecorator : IUserService
    {
        private readonly IUserService _decoratedService;

        public UserDecorator(IUserService decoratedService) { 
            _decoratedService = decoratedService;
        }

        public virtual Task<User> CreateUser(UserPost userPost)
        {
            return _decoratedService.CreateUser(userPost);
        }

        public virtual Task DeleteUser(Guid id)
        {
            return _decoratedService.DeleteUser(id);
        }

        public virtual Task<List<User>> GetAllUsers()
        {
            return _decoratedService.GetAllUsers();
        }

        public virtual Task<User?> GetUserById(Guid id)
        {
            return _decoratedService.GetUserById(id);
        }

        public virtual Task<User> UpdateUser(Guid id, UserPut userUpdate)
        {
            return _decoratedService.UpdateUser(id, userUpdate);
        }
    }
}
