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

        public static Workout ToWorkoutFromNewWorkoutDto(this NewWorkoutDto newWorkoutDto, string userId)
        {
            return new Workout
            {
                Name = newWorkoutDto.Name,
                UserId = userId,
                Exercises = newWorkoutDto.Exercises.Select(exerciseDto => new WorkoutExercise
                {
                    ExerciseId = exerciseDto.ExerciseId,
                    Sets = exerciseDto.Sets.Select(setDto => new ExerciseSet
                    {
                        Reps = setDto.Reps,
                        Weight = setDto.Weight
                    }).ToList()
                }).ToList()
            };
        }
    }
}
