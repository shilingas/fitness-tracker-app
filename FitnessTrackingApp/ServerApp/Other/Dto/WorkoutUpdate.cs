using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class WorkoutUpdate
    {
        [Required]
        public string Name { get; set; }
    }
}
