using FitnessTrackingApp.ServerApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserExerciseGet
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid UserId { get; set; }
        public double? MaxWeight { get; set; }
        public int? MaxReps { get; set; }
    }
}
