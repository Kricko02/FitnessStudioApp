using FitnessStudioApp.ViewModels;

namespace FitnessStudioApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        BindingContext = ResolveViewModel();

    }

    private ProfileViewModel ResolveViewModel()
    {
        // Retrieve the service provider
        var serviceProvider = MauiProgram.Services;
        // Resolve the LoginViewModel
        var profileViewModel = serviceProvider.GetService<ProfileViewModel>();
        return profileViewModel;
    }
}
