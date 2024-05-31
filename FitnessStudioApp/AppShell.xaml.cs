namespace FitnessStudioApp.Views
{
    public partial class AppShell : Shell
    {
        public LocalizationResourceManager LocalizationResourceManager
     => LocalizationResourceManager.Instance;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RegisterPage),typeof(RegisterPage));
            Routing.RegisterRoute(nameof(LoginPage),typeof(LoginPage));
            Routing.RegisterRoute(nameof(WorkoutsPage),typeof(WorkoutsPage));
            Routing.RegisterRoute(nameof(ProfilePage),typeof(ProfilePage));
            Routing.RegisterRoute(nameof(SocialPage), typeof(SocialPage));
            BindingContext = this;
        }
    }
}
