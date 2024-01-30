using ForgetMeNot.Pages;
using ForgetMeNot.ViewModels;

namespace ForgetMeNot;

public partial class App : Application
{
    public App(LoginViewModel loginViewModel)
    {
        InitializeComponent();
        MainPage = new LoginPage(loginViewModel);
    }
}
