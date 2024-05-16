﻿using FitnessStudioApp.Views;

namespace FitnessStudioApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegisterPage),typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
        }
    }
}
