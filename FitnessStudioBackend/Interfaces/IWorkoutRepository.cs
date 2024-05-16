using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetAllAsync();
        Task<Workout> CreateAsync(Workout exerciseModel);

        Task<Workout?> UpdateAsync(int id,Workout workout,string userId);
    }
}
