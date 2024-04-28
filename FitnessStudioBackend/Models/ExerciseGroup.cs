namespace FitnessStudioBackend.Models
{
    public class ExerciseGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
