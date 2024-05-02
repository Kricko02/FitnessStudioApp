using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class ExerciseMapper
    {
        public static ExerciseDto ToExerciseDto(this Exercise exerciseModel)
        {
            return new ExerciseDto
            {
                Id = exerciseModel.Id,
                Name = exerciseModel.Name,
                ExerciseGroupId = exerciseModel.ExerciseGroupId
            };
        }
        
        public static Exercise ToExerciseFromRequestDto(this RequestExerciseDto exerciseDto,int exericseGroupId)
        {
            return new Exercise 
            {
                Name = exerciseDto.Name,
                ExerciseGroupId= exericseGroupId
            };
        }

        public static ExerciseDto ToExerciseName(this Exercise exerciseModel)
        {
            return new ExerciseDto
            {
                Name = exerciseModel.Name,
              
            };
        }
    }
}
