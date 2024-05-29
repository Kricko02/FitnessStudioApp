
using System.Collections.ObjectModel;


namespace FitnessStudioApp.Models.WorkoutExercise
{
    public class ExerciseRequestcs
    {
        public int exerciseId { get; set; }
        public ObservableCollection<SetsRequest> sets { get; set; } = new ObservableCollection<SetsRequest>();
    }
}
