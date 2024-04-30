namespace FitnessStudioBackend.Dtos.Exercise
{
    public class ExerciseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ExerciseGroupId { get; set; }
    }
}
