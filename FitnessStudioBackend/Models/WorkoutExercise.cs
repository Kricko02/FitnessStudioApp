using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Models
{
    public class WorkoutExercise
    {
        [Key]
        public int WorkoutExerciseId { get; set; }
        public int? ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
        public int? WorkoutId { get; set; }
        public Workout? Workout { get; set; }
        public List<ExerciseSet>? Sets { get; set; }
    }
}
