using FitnessTrackingApp.ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.DataContext
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        
        public WorkoutContext(DbContextOptions options) : base(options)
        {

        }
    }
}
