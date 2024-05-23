using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserPost
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public float? Weight { get; set; }

        public int? Heigth { get; set; }

        public int? GoalWeight { get; set; }
    }
}
