using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.Sets;
using FitnessStudioBackend.Dtos.Workout;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Dtos.WorkoutExercise
{
    public class WokoutExerciseDto
    {
        public int WorkoutExerciseId { get; set; }
        public int? ExerciseId { get; set; }
        public ExerciseDto Exercise { get; set; }
        //public int? WorkoutId { get; set; }
        //public WorkoutDto? Workout { get; set; }
        public List<SetsDto>? Sets { get; set; }
    }
}
