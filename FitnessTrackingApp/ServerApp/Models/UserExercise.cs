using FitnessTrackingApp.ServerApp.Other.Dto;
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

        [Required]
        public Guid UserId { get; set; }

        [InverseProperty(nameof(Workout.UserExercises))]
        public ICollection<Workout> Workouts { get; set; }

        public double? MaxWeight { get; set; }

        public int? MaxReps { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }

        public UserExercise()
        {
            
        }

        public UserExercise(UserExercisePost userExercisePost)
        {
            ExerciseId = userExercisePost.ExerciseId;
            UserId = userExercisePost.UserId;
            MaxWeight = userExercisePost.MaxWeight;
            MaxReps = userExercisePost.MaxReps;
            Workouts  = new List<Workout>();
        }
    }
}
