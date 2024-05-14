using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.Set;

namespace FitnessStudioBackend.Dtos.WrokoutExercise
{
    public class UpdateWorkoutExerciseDto
    {
        public int WorkoutExerciseId { get; set; }
        public int? ExerciseId { get; set; }

        public List<UpdateSetDto>? Sets { get; set; }
    }
}
