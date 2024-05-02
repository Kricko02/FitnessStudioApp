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

        public Task<Workout> CreateAsync(Workout exerciseModel)
        {
            throw new NotImplementedException();
        }

        public Task<List<Workout>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //public async Task<Workout> CreateAsync(Workout exerciseModel)
        //{
        //    await _context.Workouts.AddAsync(exerciseModel);
        //    await _context.SaveChangesAsync();
        //    return exerciseModel;
        //}

        //public async  Task<List<Workout>> GetAllAsync()
        //{
        //    return await _context.Workouts.Include(w => w.Exercises).ThenInclude(we => we.Exercise).Include(w => w.Exercises).ThenInclude(we => we.Sets).ToListAsync();
        //}
    }
}
