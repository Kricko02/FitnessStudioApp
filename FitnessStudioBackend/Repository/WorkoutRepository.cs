using FitnessStudioBackend.Data;
using FitnessStudioBackend.Interfaces;
using FitnessStudioBackend.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessStudioBackend.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly ApplicationDBContext _context;
        public WorkoutRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Workout>> GetAllAsync()
        {
            return await _context.Workout
         .Include(u => u.User)
         .Include(w => w.Exercises)
             .ThenInclude(we => we.Exercise)
         .Include(w => w.Exercises)
             .ThenInclude(we => we.Sets)
         .OrderByDescending(w => w.WorkoutId) // Order by Id in descending order
         .ToListAsync();
        }

        public async Task<Workout> CreateAsync(Workout exerciseModel)
        {
            await _context.Workout.AddAsync(exerciseModel);
            await _context.SaveChangesAsync();
            return exerciseModel;
        }

        public async Task<Workout?> UpdateAsync(int id, Workout workout,string userId)
        {
            var existingWorkout = await _context.Workout
        .Include(w => w.Exercises)
        .ThenInclude(e => e.Sets)
        .FirstOrDefaultAsync(w => w.WorkoutId == id);
            


            if (existingWorkout == null || existingWorkout.UserId != userId)
            {
                return null;
            }

            // Update workout properties
            existingWorkout.Name = workout.Name;

            foreach (var updatedExercise in workout.Exercises)
            {
                // Ensure existing exercises collection is not null
                if (existingWorkout.Exercises == null)
                {
                    existingWorkout.Exercises = new List<WorkoutExercise>();
                }

                var existingExercise = existingWorkout.Exercises.FirstOrDefault(e => e.WorkoutExerciseId == updatedExercise.WorkoutExerciseId);
                if (existingExercise != null)
                {
                    // Update existing exercise sets
                    foreach (var updatedSet in updatedExercise.Sets)
                    {
                        var existingSet = existingExercise.Sets.FirstOrDefault(s => s.Id == updatedSet.Id);
                        if (existingSet != null)
                        {
                            existingSet.Reps = updatedSet.Reps;
                            existingSet.Weight = updatedSet.Weight;
                        }
                        else
                        {
                            existingExercise.Sets.Add(new ExerciseSet
                            {
                                Reps = updatedSet.Reps,
                                Weight = updatedSet.Weight
                            });
                        }
                    }
                }
                else
                {
                    var newExercise = new WorkoutExercise
                    {
                        ExerciseId = updatedExercise.ExerciseId,
                        Sets = updatedExercise.Sets.Select(setDto => new ExerciseSet
                        {
                            Reps = setDto.Reps,
                            Weight = setDto.Weight
                        }).ToList()
                    };
                    existingWorkout.Exercises.Add(newExercise);
                }
            }


            await _context.SaveChangesAsync();
            return existingWorkout;
        }

        public async Task<List<Workout>> GetUserWorkouts(string userId)
        {
            return await _context.Workout.Where(w => w.UserId == userId).Include(u=>u.User).Include(w => w.Exercises).ThenInclude(we => we.Exercise).Include(w => w.Exercises).ThenInclude(we => we.Sets).ToListAsync();
            
        }
    }
}
