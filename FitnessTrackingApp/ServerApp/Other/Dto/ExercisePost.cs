using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class ExercisePost
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Category { get; set; }

        public string Description { get; set; }
    }
}
