using FitnessTrackingApp.ServerApp.Other.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [InverseProperty(nameof(UserExercise.Workouts))]
        public ICollection<UserExercise> UserExercises { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }

        public Workout()
        {

        }

        public Workout(WorkoutPost workoutPost)
        {
            Name = workoutPost.Name;
        }
    }
}
