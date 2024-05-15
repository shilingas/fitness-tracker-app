using FitnessTrackingApp.ServerApp.Other.Dto;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class User
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public float? Weight { get; set; }

        public int? Heigth { get; set; }

        public int? GoalWeight { get; set; }

        [ConcurrencyCheck]
        public Guid Version { get; set; }

        public User()
        {

        }
        public User(UserPost userPost)
        {
            Name = userPost.Name;
            Surname = userPost.Surname;
            PhoneNumber = userPost.PhoneNumber;
            Weight = userPost.Weight;
            Heigth = userPost.Heigth;
            GoalWeight = userPost.GoalWeight;
        }
    }
}
