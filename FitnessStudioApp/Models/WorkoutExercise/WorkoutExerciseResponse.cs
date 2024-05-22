using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessStudioApp.Models.WorkoutExercise
{
    public class WorkoutExerciseResponse
    {
        [JsonPropertyName("workoutExerciseId")]
        public int WorkoutExerciseId { get; set; }
        [JsonPropertyName("exerciseId")]
        public int ExerciseId { get; set; }
        [JsonPropertyName("exercise")]
        public Exercise Exercise { get; set; }
        [JsonPropertyName("sets")]
        public List<ExerciseSet> Sets { get; set; }
    }
}
