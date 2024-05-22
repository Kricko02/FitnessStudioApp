using FitnessStudioApp.Models.Login;
using FitnessStudioApp.Models.Register;
using FitnessStudioApp.Models.Workout;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudioApp.Services
{
    public interface IApiService
    {
        [Post("/api/account/login")]
        Task<LoginResponse> Login([Body] LoginRequest loginRequest);

        [Post("/api/account/register")]
        Task<LoginResponse> Register([Body] RegisterRequest registerRequest);

        [Get("/api/workout/UserWorkouts")]
        Task<List<WorkoutResponse>> GetUserWorkoutsAsync([Header("Authorization")] string token);

    }
}
