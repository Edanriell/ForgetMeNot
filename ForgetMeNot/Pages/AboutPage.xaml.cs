using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class AboutPage : ContentPage
{
    public AboutPage()
    {
        BindingContext = new AboutViewModel();
        InitializeComponent();
    }
}
