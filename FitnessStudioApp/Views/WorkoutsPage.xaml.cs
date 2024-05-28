using FitnessStudioApp.ViewModels;

namespace FitnessStudioApp.Views;

public partial class WorkoutsPage : ContentPage
{
	public WorkoutsPage()
	{
		InitializeComponent();
        BindingContext = ResolveViewModel();
    }
    private WorkoutsViewModel ResolveViewModel()
    {
        var serviceProvider = MauiProgram.Services;
        var workoutsViewModel = serviceProvider.GetService<WorkoutsViewModel>();
        return workoutsViewModel;
    }
}