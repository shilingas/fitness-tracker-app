namespace FitnessTrackingApp.ServerApp.Other.Dto
{
    public class UserExerciseDto
    {
        public Guid Id { get; set; }
        public Guid ExerciseId { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Guid> WorkoutIds { get; set; }
    }
}
