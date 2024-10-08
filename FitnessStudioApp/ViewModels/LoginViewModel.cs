﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FitnessStudioApp.Models.Login;
using FitnessStudioApp.Services;
using FitnessStudioApp.Views;
using System.Windows.Input;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FitnessStudioApp.ViewModels
{
    public partial class LoginViewModel :ObservableObject, INotifyPropertyChanged
    {
        public LocalizationResourceManager LocalizationResourceManager
      => LocalizationResourceManager.Instance;

        private readonly IApiService _apiService;

        public bool IsBusy = false;
        private string _token;

        public string Token
        {
            get => _token;
            private set { _token = value; OnPropertyChanged(); }
        }

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        public ICommand LoginCommand { get; }

        public LoginViewModel(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            LoginCommand = new Command(async () => await Login(), () => !IsBusy);
        }

        public LoginViewModel()
        {
        }

       
        async Task Login()
        {

            if (IsBusy) return;
            IsBusy = true;
            try
            {
                var loginRequest = new LoginRequest { userName = username, password = password };
                var response = await _apiService.Login(loginRequest);
                Token = response.Token;
                await SecureStorage.SetAsync("jwt_token", Token);
                await SecureStorage.SetAsync("username", response.Username);
                await SecureStorage.SetAsync("email", response.Email);
                Application.Current.MainPage = new AppShell();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Invalid credentials", ex.Message.ToString(), "OK");

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
