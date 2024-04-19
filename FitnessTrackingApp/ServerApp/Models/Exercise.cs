using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace FitnessTrackingApp.ServerApp.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
    }
}
