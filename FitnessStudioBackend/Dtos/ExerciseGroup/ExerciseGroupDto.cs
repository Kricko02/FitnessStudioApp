using FitnessStudioBackend.Dtos.Exercise;

namespace FitnessStudioBackend.Dtos.ExerciseGroup
{
    public class ExerciseGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ExerciseDto> Exercises { get; set; } = new List<ExerciseDto>();
    }
}
