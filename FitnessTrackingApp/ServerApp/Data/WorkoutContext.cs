using FitnessTrackingApp.ServerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessTrackingApp.ServerApp.DataContext
{
    public class WorkoutContext : DbContext
    {
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserExercise> UserExercises { get; set; }
        
        public WorkoutContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserExercise>()
                .HasOne(e => e.Workout)
                .WithMany(w => w.UserExercises)
                .HasForeignKey(e => e.WorkoutId);

            modelBuilder.Entity<Exercise>()
               .Property(p => p.Version)
               .IsConcurrencyToken();

            modelBuilder.Entity<Workout>()
               .Property(p => p.Version)
               .IsConcurrencyToken();

            modelBuilder.Entity<User>()
               .Property(p => p.Version)
               .IsConcurrencyToken();

            modelBuilder.Entity<UserExercise>()
               .Property(p => p.Version)
               .IsConcurrencyToken();
        }
    }
}
