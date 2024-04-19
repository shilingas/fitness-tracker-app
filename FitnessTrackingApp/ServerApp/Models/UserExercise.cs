using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class UserExercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid  ExerciseId { get; set; }

        [ForeignKey("ExerciseId")]
        public Exercise Exercise { get; set; }

        public Guid WorkoutId { get; set; }

        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("WorkoutId")]
        public User User { get; set; }

        public double MaxWeight { get; set; }

        public int MaxReps { get; set; }
    }
}
