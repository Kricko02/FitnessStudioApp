﻿using FitnessStudioBackend.Dtos.Exercise;
using FitnessStudioBackend.Dtos.Set;

namespace FitnessStudioBackend.Dtos.WrokoutExercise
{
    public class WorkoutExerciseDto
    {
        public int WorkoutExerciseId { get; set; }
        public int? ExerciseId { get; set; }
        public ExerciseDto Exercise { get; set; }
        
        public List<SetsDto>? Sets { get; set; }
    }
}
