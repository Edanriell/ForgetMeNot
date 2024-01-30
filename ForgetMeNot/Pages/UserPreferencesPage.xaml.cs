using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class UserPreferencesPage : ContentPage
{
    public UserPreferencesPage()
    {
        BindingContext = new UserPreferencesViewModel();
        InitializeComponent();
    }
}
