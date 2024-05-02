using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessStudioBackend.Controllers
{
    [Route("api/exerciseGroup")]
    [ApiController]
    public class ExerciseGroupController : Controller
    {
        private readonly IExerciseGroupRepository _exerciseGroupRepo;
        public ExerciseGroupController(IExerciseGroupRepository exerciseGroupRepo)
        {
            _exerciseGroupRepo = exerciseGroupRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercise = await _exerciseGroupRepo.GetAllAsync();
            var exerciseDto = exercise.Select(s => s.ToExerciseGroupDto());
            return Ok(exerciseDto);
        }

    }
}
