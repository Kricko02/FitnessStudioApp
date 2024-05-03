using FitnessStudioBackend.Data;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessStudioBackend.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDBContext _context;
        public WorkoutRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Workout>> GetAllAsync()
        {
            return await _context.Workout.Include(w => w.Exercises).ThenInclude(we => we.Exercise).Include(w => w.Exercises).ThenInclude(we => we.Sets).ToListAsync();
        }
    }
}
