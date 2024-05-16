
using FitnessStudioApp.Views;

namespace FitnessStudioApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
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

    private void bt_SignIn_Clicked(object sender, TouchEventArgs e)
    {
        if (CheckTextBoxes())
        {
            if (CheckUser())
            {
                //prejmeš žeton in prijaviš uporabnika
            }
            else 
            { 
                ResetMessages();
                tb_password.Text = "";
                tb_password.SupportingText = "Enter password is incorect!";
            }
        }
    }
    private void bt_register_Clicked(object sender, TouchEventArgs e)
    {
        Navigation.PopModalAsync();
        Navigation.PushModalAsync(new RegisterPage());
    }
    private bool CheckUser()//logika za prijavo 
    {
        return true;
    }
    private void ResetMessages()
    {
        tb_password.SupportingText = "";
        tb_username.SupportingText = "";
    }
    private bool CheckTextBoxes()
    {
        ResetMessages();
        if (tb_username.Text.Length == 0)
        {
            tb_username.SupportingText = "Enter username!";
            return false;
        }
        if (tb_password.Text.Length == 0)
        {
            tb_password.SupportingText = "Enter password!";
            return false;
        }
        return true;
    }
}