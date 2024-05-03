using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FitnessStudioBackend.Controllers
{
    [Route("api/workout")]
    [ApiController]
    public class WorkoutController : Controller
    {
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutController(IWorkoutRepository workoutRepository)
        {
            _workoutRepository = workoutRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var workout = await _workoutRepository.GetAllAsync();
            var workoutDto = workout.Select(s => s.ToWorkoutDto());
            return Ok(workoutDto);
        }
    }
}
