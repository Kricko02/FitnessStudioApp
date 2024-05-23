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
        public int workoutExerciseId { get; set; }
        [JsonPropertyName("exerciseId")]
        public int exerciseId { get; set; }
        [JsonPropertyName("exercise")]
        public Exercise exercise { get; set; }
        [JsonPropertyName("sets")]
        public List<ExerciseSet> sets { get; set; }
    }
}
