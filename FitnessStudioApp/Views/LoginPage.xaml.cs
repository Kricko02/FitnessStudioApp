namespace FitnessStudioApp;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		
	}

    private void tb_password_TrailingIconClicked(object sender, EventArgs e)
    {
		if (tb_password.TrailingIconData== IconPacks.IconKind.Material.VisibilityOff)
		{
			tb_password.InputType = Material.Components.Maui.Primitives.InputType.SingleLine;
			tb_password.TrailingIconData = IconPacks.IconKind.Material.Visibility;
        }
		else 
		{
			tb_password.InputType = Material.Components.Maui.Primitives.InputType.Password;
			tb_password.TrailingIconData = IconPacks.IconKind.Material.VisibilityOff;
        }
    }
}