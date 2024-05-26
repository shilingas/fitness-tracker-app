using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class History
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public decimal NewWeight { get; set; }

        public DateTime UpdatedDate { get; set; }

        public History()
        {

        }

        public History(Guid userId, decimal newWeight)
        {
            UserId = userId;
            NewWeight = newWeight;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
