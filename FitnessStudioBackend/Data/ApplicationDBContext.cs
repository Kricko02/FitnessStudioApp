using FitnessStudioBackend.Models;
using Microsoft.EntityFrameworkCore;


namespace FitnessStudioBackend.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<ExerciseGroup> ExerciseGroup { get; set; }

    }
}
