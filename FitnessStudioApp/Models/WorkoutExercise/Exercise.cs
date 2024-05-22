using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessStudioApp.Models.WorkoutExercise
{
    public class Exercise
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("exerciseGroupId")]
        public int ExerciseGroupId { get; set; }
    }
}
