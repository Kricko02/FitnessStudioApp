﻿using System.ComponentModel.DataAnnotations;

namespace FitnessStudioBackend.Models
{
    public class ExerciseSet
    {
        [Key]
        public int Id { get; set; }
        public int Reps { get; set; }
        public double Weight { get; set; }
        public int WorkoutExerciseId { get; set; }
        public WorkoutExercise WorkoutExercise { get; set; }
    }
}
