using FitnessStudioBackend.Dtos.Set;
using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Mappers
{
    public static class SetMapper
    {
        public static SetsDto ToSetDto(this ExerciseSet exerciseSetModel)
        {
            return new SetsDto
            {
                Reps = exerciseSetModel.Reps,
                Weight = exerciseSetModel.Weight,
            };
        }
    }
}

