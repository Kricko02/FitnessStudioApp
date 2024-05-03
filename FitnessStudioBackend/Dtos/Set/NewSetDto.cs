using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Dtos.Set
{
    public class NewSetDto
    {
      
        public int Reps { get; set; }
        public double Weight { get; set; }
    }
}
