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
        public int id { get; set; }
        [JsonPropertyName("reps")]
        public int reps { get; set; }
        [JsonPropertyName("weight")]
        public double weight { get; set; }
    }
}
