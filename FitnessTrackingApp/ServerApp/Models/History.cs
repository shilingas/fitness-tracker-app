using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using FitnessTrackingApp.ServerApp.Other.Dto;

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

        public History(HistoryPost historyPost)
        {
            UserId = historyPost.UserId;
            NewWeight = historyPost.NewWeight;
            UpdatedDate = DateTime.UtcNow;
        }
    }
}
