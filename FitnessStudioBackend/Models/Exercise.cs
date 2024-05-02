namespace FitnessStudioBackend.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? ExerciseGroupId { get; set; }
        public ExerciseGroup? ExerciseGroup { get; set; }
    }
}
