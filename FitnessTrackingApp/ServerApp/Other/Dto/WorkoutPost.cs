using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class WorkoutPost
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
