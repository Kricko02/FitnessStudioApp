using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Models
{
    public class Workout
    {
        [Key]
        public int WorkoutId { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; } 
        public AppUser User { get; set; } 
        public List<WorkoutExercise> Exercises { get; set; }

    }
}
