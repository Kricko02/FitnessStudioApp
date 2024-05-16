using FitnessStudioBackend.Dtos.WrokoutExercise;

namespace FitnessStudioBackend.Dtos.Workout
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<WorkoutExerciseDto> Exercises { get; set; }
    }
}
