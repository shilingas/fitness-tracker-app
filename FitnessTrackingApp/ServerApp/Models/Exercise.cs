using FitnessTrackingApp.ServerApp.Other.Dto;
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

        [Required]
        public string Category {  get; set; }

        public string? Description { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }


        public Exercise()
        {
        }

        public Exercise(ExercisePost exercisePost)
        {
            Title = exercisePost.Title;
            Category = exercisePost.Category;
            Description = exercisePost.Description;
        }
    }
}
