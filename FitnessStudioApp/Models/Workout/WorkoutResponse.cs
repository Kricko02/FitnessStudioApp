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
    public class WorkoutResponse 
    {
        
        public int id { get; set; }
     
        public string name { get; set; }
       
        public string useriId { get; set; }
        public string userName { get; set; }
        
        public List<WorkoutExerciseResponse> exercises { get; set; }

       
    }
}
