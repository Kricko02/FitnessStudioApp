﻿namespace FitnessStudioBackend.Dtos.Exercise
{
    public class RequestExerciseDto
    {
        public string Name { get; set; } = string.Empty;
        public int? ExerciseGroupId { get; set; }
    }
}
