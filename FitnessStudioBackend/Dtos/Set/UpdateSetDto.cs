using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Dtos.Set
{
    public class UpdateSetDto
    {
        public int Id { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
   
    }
}
