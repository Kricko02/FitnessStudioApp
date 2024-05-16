using System.Text.RegularExpressions;

namespace FitnessStudioApp.Views;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}
    private void tb_password_TrailingIconClicked(object sender, EventArgs e)
    {
        if (tb_password.TrailingIconData == IconPacks.IconKind.Material.VisibilityOff)
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
    private void tb_passwordRepeat_TrailingIconClicked(object sender, EventArgs e)
    {
        if (tb_passwordRepeat.TrailingIconData == IconPacks.IconKind.Material.VisibilityOff)
        {
            tb_passwordRepeat.InputType = Material.Components.Maui.Primitives.InputType.SingleLine;
            tb_passwordRepeat.TrailingIconData = IconPacks.IconKind.Material.Visibility;
        }
        else
        {
            tb_passwordRepeat.InputType = Material.Components.Maui.Primitives.InputType.Password;
            tb_passwordRepeat.TrailingIconData = IconPacks.IconKind.Material.VisibilityOff;
        }
    }
    private void bt_register_Clicked(object sender, TouchEventArgs e)
    {
        if (CheckTextBoxes())
        {
            //napiši registracijo do konca
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new LoginPage());
        }
    }

    private void bt_signIn_Clicked(object sender, TouchEventArgs e)
    {
        Navigation.PopModalAsync();
        Navigation.PushModalAsync(new LoginPage());
    }
    private void ResetMessages()
    {
        tb_username.SupportingText = "";
        tb_email.SupportingText = "";
        tb_password.SupportingText = "";
        tb_passwordRepeat.SupportingText = "";
    }
    private bool CheckTextBoxes()
    {
        ResetMessages();
        if (tb_username.Text.Length == 0)
        {
            tb_username.SupportingText = "Enter username!";
            return false;
        }
        if (tb_email.Text.Length == 0)
        {
            tb_username.SupportingText = "Enter email!";
            return false;
        }
        if (tb_password.Text.Length == 0)
        {
            tb_password.SupportingText = "Enter password!";
            return false;
        }
        if (tb_passwordRepeat.Text.Length == 0)
        {
            tb_passwordRepeat.SupportingText = "Repeat password!";
            return false;
        }
        if (!IsStrong())
        {
            return false;
        }
        if (tb_password.Text!=tb_passwordRepeat.Text)
        {
            tb_passwordRepeat.SupportingText = "Passwords don't match!";
            return false;
        }
        return true;
    }
    private bool IsStrong()
    {
        if (tb_password.Text.Length<12)
        {
            tb_password.SupportingText = "Password must be 12 characters long!";
            return false; ;
        }
        if (!tb_password.Text.Any(char.IsUpper))
        { 
            tb_password.SupportingText = "Password must contain 1 uppercase letter!";
            return false; 
        }
        if (tb_password.Text.All(char.IsLetterOrDigit))
        {
            tb_password.SupportingText = "Password must contain 1 special character!";
            return false; ;
        }
        return true;
    }
}