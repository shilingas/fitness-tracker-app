using FitnessTrackingApp.ServerApp.DataContext;
using FitnessTrackingApp.ServerApp.Models;

namespace FitnessTrackingApp.ServerApp.Services
{
    public class ExerciseService
    {
        private readonly WorkoutContext _context;

        public ExerciseService(WorkoutContext context)
        {
            _context = context;
        }

        public void AddExercise(string name)
        {

        }
    }
}
