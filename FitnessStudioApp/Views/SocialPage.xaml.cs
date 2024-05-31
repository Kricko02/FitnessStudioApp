using FitnessStudioApp.Resources.Languages;
using FitnessStudioApp.ViewModels;
using System.Globalization;
namespace FitnessStudioApp.Views;

public partial class SocialPage : ContentPage
{

    private SocialViewModel _viewModel;
    public SocialPage()
	{
        InitializeComponent();
        _viewModel = ResolveViewModel();
        BindingContext = _viewModel;
    }

    private SocialViewModel ResolveViewModel()
    {
        var serviceProvider = MauiProgram.Services;
        var socialViewModel = serviceProvider.GetService<SocialViewModel>();
        return socialViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel != null)
        {
            await _viewModel.InitializeAsync();
        }
    }
}