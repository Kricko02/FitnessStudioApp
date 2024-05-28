using CommunityToolkit.Mvvm.ComponentModel;
using FitnessStudioApp.Models.Register;
using FitnessStudioApp.Services;
using FitnessStudioApp.Views;
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
    partial class RegisterViewModel: ObservableObject, INotifyPropertyChanged
    {
        public LocalizationResourceManager LocalizationResourceManager
      => LocalizationResourceManager.Instance;

        private readonly IApiService _apiService;

        public bool IsBusy = false;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string emailAddress;

        [ObservableProperty]
        string password;
        public ICommand RegisterCommand { get; }

        public RegisterViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            RegisterCommand = new Command(async () => await Register(), () => !IsBusy);
        }

        async Task Register()
        {
            if (IsBusy) return;

            IsBusy = true;
            try
            {
                var registerRequest = new RegisterRequest { username = username, emailAddress =emailAddress, password = password };
                var response = await _apiService.Register(registerRequest);
                Application.Current.MainPage = new LoginPage();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error",ex.Message.ToString() , "OK");

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
