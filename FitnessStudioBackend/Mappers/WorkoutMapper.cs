using FitnessStudioBackend.Dtos.Workout;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class WorkoutMapper
    {
        public static WorkoutDto ToWorkoutDto(this Workout workoutModel)
        {
            return new WorkoutDto
            {
                Id = workoutModel.WorkoutId,
                Name = workoutModel.Name,
                UserId = workoutModel.UserId,
                Exercises = workoutModel.Exercises.Select(c => c.ToWorkoutExerciseDto()).ToList()
            };
        }
    }
}
