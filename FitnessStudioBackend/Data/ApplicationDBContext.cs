using FitnessStudioBackend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace FitnessStudioBackend.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser >
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseGroup> ExerciseGroup { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }

        

    }
}
