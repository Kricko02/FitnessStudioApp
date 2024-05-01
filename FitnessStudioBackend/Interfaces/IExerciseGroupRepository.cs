using FitnessStudioBackend.Models;

namespace FitnessStudioBackend.Interfaces
{
    public interface IExerciseGroupRepository
    {
        Task<List<ExerciseGroup>> GetAllAsync();

        Task<bool> ExerciseGroupExists(int id);
    }
}
