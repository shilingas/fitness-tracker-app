using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public byte[]? ImageData { get; set; }

        public Exercise(string title)
        {
            Title = title;
        }
    }
}
