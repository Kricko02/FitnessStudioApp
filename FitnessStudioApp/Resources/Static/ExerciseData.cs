using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudioApp.Resources.Static
{
    public class ExerciseData
    {
        public static Dictionary<string, int> exercisesData = new Dictionary<string, int>
    {
        { "Bench Press", 1 },
        { "Squats", 2 },
        { "Deadlift", 3 },
        { "Leg Press", 4 },
        { "Pull Ups", 5 }
    };
    }
}
