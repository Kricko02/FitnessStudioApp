using Microsoft.AspNetCore.Identity;

namespace FitnessStudioBackend.Models
{
    public class AppUser : IdentityUser
    {
        public List<Workout> Workouts { get; set; }
    }
}
