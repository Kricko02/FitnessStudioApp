using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Interfaces
{
    public interface IWorkoutRepository
    {
        Task<List<Workout>> GetAllAsync();
    }
}
