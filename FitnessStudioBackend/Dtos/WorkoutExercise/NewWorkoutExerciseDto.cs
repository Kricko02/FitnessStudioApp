using FitnessStudioBackend.Dtos.Sets;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Dtos.WorkoutExercise
{
    public class NewWorkoutExerciseDto
    {
    
        public int? ExerciseId { get; set; }    
        public List<NewSetDto>? Sets { get; set; }
    }
}
