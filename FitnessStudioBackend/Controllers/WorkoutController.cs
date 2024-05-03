using FitnessStudioBackend.Dtos.Workout;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
       
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] NewWorkoutDto workoutDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized();
            }
            var workoutModel = workoutDto.ToWorkoutFromNewWorkoutDto(userId);
            await _workoutRepository.CreateAsync(workoutModel);
            return Ok("Workout created succesfully");
        }
    }
}
