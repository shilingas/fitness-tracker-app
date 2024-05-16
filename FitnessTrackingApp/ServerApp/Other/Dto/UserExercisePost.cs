using FitnessTrackingApp.ServerApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserExercisePost
    {
        [Required]
        public Guid ExerciseId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public double? MaxWeight { get; set; }

        public int? MaxReps { get; set; }

    }
}
