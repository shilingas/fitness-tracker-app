using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserUpdate
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public float? Weight { get; set; }

        public int? Heigth { get; set; }

        public int? GoalWeight { get; set; }
    }
}
