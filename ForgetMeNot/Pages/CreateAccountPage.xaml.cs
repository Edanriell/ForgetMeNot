using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class CreateAccountPage : ContentPage
{
    public CreateAccountPage(CreateAccountViewModel vm)
    {
        BindingContext = vm;
        InitializeComponent();
    }
}
