using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.ExerciseGroup;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class ExerciseGroupMapper
    {
        public static ExerciseGroupDto ToExerciseGroupDto(this ExerciseGroup exerciseGroupModel)
        {
            return new ExerciseGroupDto
            {
                Id = exerciseGroupModel.Id,
                Name = exerciseGroupModel.Name,
                Exercises = exerciseGroupModel.Exercises.Select(c=>c.ToExerciseDto()).ToList()
            };

            
        }
    }
}
