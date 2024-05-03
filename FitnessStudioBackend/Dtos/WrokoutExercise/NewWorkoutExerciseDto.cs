using FitnessStudioBackend.Dtos.Account;
using FitnessStudioBackend.Dtos.Set;

namespace FitnessStudioBackend.Dtos.WrokoutExercise
{
    public class NewWorkoutExerciseDto
    {
        public int? ExerciseId { get; set; }
        public List<NewSetDto>? Sets { get; set; }
    }
}
