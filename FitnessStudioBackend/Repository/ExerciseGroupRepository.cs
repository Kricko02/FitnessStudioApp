using FitnessStudioBackend.Data;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessStudioBackend.Repository
{
    public class ExerciseGroupRepository:IExerciseGroupRepository
    {
        private readonly ApplicationDBContext _context;

        public ExerciseGroupRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Task<bool> ExerciseGroupExists(int id)
        {
           return _context.Exercise.AnyAsync(s => s.Id == id);
        }

        public async Task<List<ExerciseGroup>> GetAllAsync()
        {
            return await _context.ExerciseGroup.Include(c => c.Exercises).ToListAsync();
        }
    }
}
