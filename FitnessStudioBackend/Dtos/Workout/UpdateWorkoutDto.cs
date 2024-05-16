using FitnessStudioBackend.Dtos.WrokoutExercise;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Dtos.Workout
{
    public class UpdateWorkoutDto
    {
        public string Name { get; set; }
        public List<UpdateWorkoutExerciseDto> Exercises { get; set; }

    }
}
