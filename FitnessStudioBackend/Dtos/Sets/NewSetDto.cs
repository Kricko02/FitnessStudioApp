using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Dtos.Sets
{
    public class NewSetDto
    {
        [Required]
        public int Reps { get; set; }
        [Required]
        public double Weight { get; set; }
        
    }
}
