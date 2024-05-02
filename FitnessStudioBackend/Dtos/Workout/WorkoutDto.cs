using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.WorkoutExercise;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Dtos.Workout
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        //public AppUser User { get; set; }
        public List<WokoutExerciseDto> Exercises { get; set; }
    }
}
