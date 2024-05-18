using FitnessStudioApp.Models.Login;
using FitnessStudioApp.Services;
using FitnessStudioApp.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FitnessStudioApp.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private readonly IApiService _apiService;
        private string _username;
        private string _password;
        private bool _isBusy;
        private string _token;


        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public string Token
        {
            get => _token;
            private set { _token = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            LoginCommand = new Command(async () => await Login(), () => !IsBusy);
        }

        private async Task Login()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var loginRequest = new LoginRequest { userName = "tilen", password = "P@ssword_0161" };// tu je hardcoded moglo bi bit Username in Passowrd namesto tilen in ....
                var response = await _apiService.Login(loginRequest);
                Token = response.Token;
                await SecureStorage.SetAsync("jwt_token", Token);

                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message.ToString(), "OK");
              
            }
            finally
            {
                IsBusy = false;
            }
        }

   
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
