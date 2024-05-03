using FitnessStudioBackend.Dtos.WrokoutExercise;

namespace FitnessStudioBackend.Dtos.Workout
{
    public class NewWorkoutDto
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<NewWorkoutExerciseDto> Exercises { get; set; }
    }
}
