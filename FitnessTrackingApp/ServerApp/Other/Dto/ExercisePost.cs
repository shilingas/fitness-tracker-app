using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class ExercisePost
    {
        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public byte[]? ImageData { get; set; }
    }
}
