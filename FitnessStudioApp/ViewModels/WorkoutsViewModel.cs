using CommunityToolkit.Mvvm.ComponentModel;
using FitnessStudioApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessStudioApp.ViewModels
{
    public class WorkoutsViewModel : ObservableObject, INotifyPropertyChanged
    {
        public LocalizationResourceManager LocalizationResourceManager
     => LocalizationResourceManager.Instance;

        private readonly IApiService _apiService;
        private string _username;
        private string _email = "tilen@gmail.com";
        private string _token;
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

        //public List<WorkoutResponse> UserWorkouts
        //{
        //    get => userWorkouts;
        //    set { userWorkouts = value; OnPropertyChanged(); }
        //}

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
        public ICommand FinishComand { get; }
        public WorkoutsViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            //FinishComand = new Command(async () => await Login(), () => !IsBusy);  tole je treba popravit
            InitializeAsync();
        }
        private async Task InitializeAsync()
        {
            await LoadUsernameAsync();
            //await GetUserWorkoutsAsync();
        }
        private async Task LoadUsernameAsync()
        {
            Username = await SecureStorage.GetAsync("username");
            Token = await SecureStorage.GetAsync("jwt_token");
        }
    }
}
