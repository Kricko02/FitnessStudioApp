using FitnessStudioBackend.Data;
using FitnessStudioBackend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FitnessStudioBackend.Controllers
{
    [Route("api/exercise")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ExerciseController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var exercise = _context.Exercise.ToList().Select(s => s.ToExerciseDto());
            return Ok(exercise);
        }

        [HttpGet("{gorupId}")]
        public IActionResult GetExerciseByGroup([FromRoute] int gorupId)
        {
            var exercise = _context.Exercise.Where(e => e.ExerciseGroupId == gorupId).ToList().Select(s => s.ToExerciseDto());
            if (exercise == null) { return NotFound(); }

            return Ok(exercise);
        }
    }
}
