using FitnessStudioApp.Models.WorkoutExercise;
using FitnessStudioApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudioApp.Models.Workout
{
    public class WorkoutRequest
    {
        public string name { get; set; }
        public ObservableCollection<ExerciseViewModel> exercises { get; set; } = new ObservableCollection<ExerciseViewModel>();
    }
}
