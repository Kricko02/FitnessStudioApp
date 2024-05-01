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
       
        private readonly IExerciseRepository _exerciseRepo;
        private readonly IExerciseGroupRepository _exerciseGroupRepo;
        public ExerciseController(IExerciseRepository exerciseRepo, IExerciseGroupRepository exerciseGroupRepo)
        {
            _exerciseRepo= exerciseRepo;
            _exerciseGroupRepo= exerciseGroupRepo;
           
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var exercise = await _exerciseRepo.GetAllAsync();
            var exerciseDto= exercise.Select(s => s.ToExerciseDto());
            return Ok(exerciseDto); 
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var exercise = await _exerciseRepo.GetByIdAsync(id);

            if (exercise == null)
            { 
                return NotFound();
            }
            return Ok(exercise.ToExerciseDto());
        }

        [HttpGet("group/{groupId:int}")]
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

        [HttpPost("{exerciseGroupId:int}")]
        public async Task<IActionResult> Create([FromRoute] int exerciseGroupId,RequestExerciseDto exerciseDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(!await _exerciseGroupRepo.ExerciseGroupExists(exerciseGroupId))
            {
                return BadRequest("Exercise group does not exist");
            }
            var exerciseModel = exerciseDto.ToExerciseFromRequestDto(exerciseGroupId);
            await _exerciseRepo.CreateAsync(exerciseModel);
            return CreatedAtAction(nameof(GetById), new {id=exerciseModel.Id},exerciseModel.ToExerciseDto()); //Will change the response later right now for test purposes
        }
    }
}
