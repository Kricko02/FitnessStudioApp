using FitnessStudioBackend.Data;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Mappers;
using FitnessStudioBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace FitnessStudioBackend.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly  ApplicationDBContext _context;
        public ExerciseRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Exercise> CreateAsync(Exercise exerciseModel)
        {
            await _context.Exercise.AddAsync(exerciseModel);
            await _context.SaveChangesAsync();
            return exerciseModel;
        }

        public async Task<List<Exercise>> GetAllAsync()
        {
            return await _context.Exercise.ToListAsync();
        }

        public async Task<List<Exercise>> GetByGroupIdAsync(int id)
        {
            var exercises = await _context.Exercise.Where(e => e.ExerciseGroupId == id).ToListAsync();
            return exercises;
        }

        public async Task<Exercise?> GetByIdAsync(int id)
        {
            return await _context.Exercise.FindAsync(id);
        }
    }
}
