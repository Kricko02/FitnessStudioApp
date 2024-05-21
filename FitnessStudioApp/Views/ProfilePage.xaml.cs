using FitnessStudioApp.ViewModels;

namespace FitnessStudioApp.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
		BindingContext = new ProfileViewModel();
	}
}