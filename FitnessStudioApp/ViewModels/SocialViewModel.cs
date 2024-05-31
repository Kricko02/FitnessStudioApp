using CommunityToolkit.Mvvm.ComponentModel;
using FitnessStudioApp.Models.Workout;
using FitnessStudioApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudioApp.ViewModels
{
    public partial class SocialViewModel: ObservableObject, INotifyPropertyChanged
    {
        public LocalizationResourceManager LocalizationResourceManager => LocalizationResourceManager.Instance;

        private readonly IApiService _apiService;
        private string _username;
        private string _email = "tilen@gmail.com";
        private string _token;
        public List<WorkoutResponse> userWorkouts;
        private int totalWeight = 1234;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }
        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }
        public List<WorkoutResponse> UserWorkouts
        {
            get => userWorkouts;
            set { userWorkouts = value; OnPropertyChanged(); }
        }
        public string Token
        {
            get => _token;
            set { _token = value; OnPropertyChanged(); }
        }
        public int TotalWeight
        {
            get => totalWeight;
            set { totalWeight = value; OnPropertyChanged(); }
        }

        public SocialViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        public async Task InitializeAsync()
        {
            await LoadUsernameAsync();
            await GetUserWorkoutsAsync();
        }

        private async Task LoadUsernameAsync()
        {
            Username = await SecureStorage.GetAsync("username");
            Token = await SecureStorage.GetAsync("jwt_token");
        }

        public async Task GetUserWorkoutsAsync()
        {
            try
            {
                if (!string.IsNullOrEmpty(Token))
                {
                    var response = await _apiService.GetAllWorkouts($"Bearer {Token}");
                    UserWorkouts = new List<WorkoutResponse>(response);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "Token is missing.", "OK");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
