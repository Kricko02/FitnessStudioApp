﻿using FitnessStudioApp.Views;

namespace FitnessStudioApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //Dodaj logiko za prijavo ali AppShell kjer je aplikacija ko je user prijavlen
            bool prijavljen=false;
            if(prijavljen )
            {
                 MainPage = new AppShell();
            }
            else
            {
                MainPage = new LoginPage();
            }

        }
    }
}
