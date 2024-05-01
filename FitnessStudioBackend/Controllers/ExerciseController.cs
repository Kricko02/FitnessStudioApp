using FitnessStudioBackend.Data;
using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FitnessStudioBackend.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly ApplicationDBContext _context;
        private readonly IExerciseRepository _exerciseRepo;
        public ExerciseController(ApplicationDBContext context,IExerciseRepository exerciseRepo)
        {
            _exerciseRepo= exerciseRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercise = await _exerciseRepo.GetAllAsync();
            var exerciseDto= exercise.Select(s => s.ToExerciseDto());
            return Ok(exerciseDto); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exercise = await _exerciseRepo.GetByIdAsync(id);

            if (exercise == null)
            { 
                return NotFound();
            }
            return Ok(exercise.ToExerciseDto());
        }

        [HttpGet("group/{groupId}")]
        public async Task<IActionResult> GetExerciseByGroup([FromRoute] int groupId)
        {
            var exercises = await _exerciseRepo.GetByGroupIdAsync(groupId);

            if (exercises == null || exercises.Count == 0)
            {
                return NotFound();
            }
            var exerciseDto = exercises.Select(s => s.ToExerciseDto());

            return Ok(exerciseDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RequestExerciseDto exerciseDto)
        {
            var exerciseModel = exerciseDto.ToExerciseFromRequestDto();
            await _exerciseRepo.CreateAsync(exerciseModel);
            return CreatedAtAction(nameof(GetById), new {id=exerciseModel.Id},exerciseModel.ToExerciseDto()); //Will change the response later right now for test purposes
        }
    }
}
