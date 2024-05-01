using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Dtos.Exercise
{
    public class RequestExerciseDto
    {
        [Required]
        [MinLength(5,ErrorMessage ="Name must be atleast 5 characters long")]
        [MaxLength(50, ErrorMessage = "Name cannot be over 50 characters ")]

        public string Name { get; set; } = string.Empty;
    }
}
