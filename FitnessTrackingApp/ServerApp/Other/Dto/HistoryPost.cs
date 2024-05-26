using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class HistoryPost
    {
        [Required]
        public Guid UserId { get; set; }

        [Required]
        public decimal NewWeight { get; set; }
    }
}
