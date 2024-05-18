using FitnessStudioApp.Models.Login;
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
    }
}
