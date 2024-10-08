using FitnessStudioApp.Resources.Languages;
using FitnessStudioApp.ViewModels;
using System.Globalization;

namespace FitnessStudioApp.Views;

public partial class ProfilePage : ContentPage
{
    private ProfileViewModel _viewModel;

    public ProfilePage()
    {
        InitializeComponent();
        _viewModel = ResolveViewModel();
        BindingContext = _viewModel;
        PreveriJezik();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_viewModel != null)
        {
            await _viewModel.InitializeAsync();
        }
    }

    void PreveriJezik()
    {
        if (AppResources.Culture.TwoLetterISOLanguageName.Equals("en", StringComparison.InvariantCultureIgnoreCase))
        {
            rb_jezik.SelectedIndex = 0;
        }
        if (AppResources.Culture.TwoLetterISOLanguageName.Equals("sl", StringComparison.InvariantCultureIgnoreCase))
        {
            rb_jezik.SelectedIndex = 1;
        }
        if (AppResources.Culture.TwoLetterISOLanguageName.Equals("de", StringComparison.InvariantCultureIgnoreCase))
        {
            rb_jezik.SelectedIndex = 2;
        }
    }

    private ProfileViewModel ResolveViewModel()
    {
        // Retrieve the service provider
        var serviceProvider = MauiProgram.Services;
        // Resolve the ProfileViewModel
        var profileViewModel = serviceProvider.GetService<ProfileViewModel>();
        return profileViewModel;
    }

    private void RadioButton_SelectedChanged(object sender, SelectedItemChangedEventArgs e)
    {
        if (rb_jezik.SelectedIndex == 0)
        {
            var switchToCulture = new CultureInfo("en-US");
            LocalizationResourceManager.Instance.SetCulture(switchToCulture);
        }
        else if (rb_jezik.SelectedIndex == 1)
        {
            var switchToCulture = new CultureInfo("sl");
            LocalizationResourceManager.Instance.SetCulture(switchToCulture);
        }
        else if (rb_jezik.SelectedIndex == 2)
        {
            var switchToCulture = new CultureInfo("de");
            LocalizationResourceManager.Instance.SetCulture(switchToCulture);
        }
    }
}

