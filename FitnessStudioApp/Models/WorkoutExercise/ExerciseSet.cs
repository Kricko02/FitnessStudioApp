using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessStudioApp.Models.WorkoutExercise
{
    public class ExerciseSet
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("reps")]
        public int Reps { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
    }
}
