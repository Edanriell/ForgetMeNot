using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        passwordEntry.Text = "";
        LoginNameEntry.Text = "";
    }
}
