using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.WorkoutExercise;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class WorkoutExerciseMapper
    {
        public static WokoutExerciseDto ToWorkoutExerciseDto(this WorkoutExercise exerciseModel)
        {
            return new WokoutExerciseDto
            {
               WorkoutExerciseId=exerciseModel.WorkoutExerciseId,
               ExerciseId = exerciseModel.ExerciseId,
               Exercise=exerciseModel.Exercise.ToExerciseDto(),
               Sets=exerciseModel.Sets.Select(c => c.ToSetDto()).ToList()
            };
        }
    }
}
