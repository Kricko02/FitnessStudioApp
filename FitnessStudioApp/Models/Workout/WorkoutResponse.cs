using CommunityToolkit.Mvvm.ComponentModel;
using FitnessStudioApp.Models.WorkoutExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FitnessStudioApp.Models.Workout
{
    public class WorkoutResponse : ObservableObject
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("userId")]
        public string UseriId { get; set; }
        [JsonPropertyName("exercises")]
        public List<WorkoutExerciseResponse> Exercises { get; set; }
}
}
