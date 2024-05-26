using FitnessTrackingApp.ServerApp.IServices;
using FitnessTrackingApp.ServerApp.Models;

namespace FitnessTrackingApp.ServerApp.Decorators
{
    public class ExampleDecorator : WorkoutServiceDecorator
    {
        public ExampleDecorator(IWorkoutService decoratedService) : base(decoratedService) {}

        public override async Task<List<Workout>> GetAllWorkouts()
        {
            Console.WriteLine("GetAllWorkouts called");
            return await base.GetAllWorkouts();
        }

        public override async Task<Workout?> GetWorkoutById(Guid id)
        {
            Console.WriteLine($"GetWorkoutById called with id {id}");
            return await base.GetWorkoutById(id);
        }

    }
}
