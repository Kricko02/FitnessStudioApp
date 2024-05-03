using FitnessStudioBackend.Dtos.WrokoutExercise;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class WorkoutExerciseMapper
    {
        public static WorkoutExerciseDto ToWorkoutExerciseDto(this WorkoutExercise exerciseModel)
        {
            return new WorkoutExerciseDto
            {
                WorkoutExerciseId = exerciseModel.WorkoutExerciseId,
                ExerciseId = exerciseModel.ExerciseId,
                Exercise = exerciseModel.Exercise.ToExerciseDto(),
                Sets = exerciseModel.Sets.Select(c => c.ToSetDto()).ToList()
            };
        }
    }
}

