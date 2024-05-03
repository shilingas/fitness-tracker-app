using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class Workout
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public ICollection<UserExercise> UserExercises { get; set; }
    }
}
