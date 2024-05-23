using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserExerciseAddPost
    {
        [Required]
        public Guid UserExerciseId { get; set; }
    }
}
