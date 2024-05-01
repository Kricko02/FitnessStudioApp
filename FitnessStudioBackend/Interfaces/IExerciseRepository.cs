using FitnessStudioBackend.Models;
using System.Threading.Tasks;

namespace FitnessStudioBackend.Interfaces
{
    public interface IExerciseRepository
    {
        Task<List<Exercise>> GetAllAsync();
        Task<Exercise?> GetByIdAsync(int id);
        Task<List<Exercise>> GetByGroupIdAsync(int id);
        Task<Exercise> CreateAsync(Exercise exerciseModel);
    }
}
