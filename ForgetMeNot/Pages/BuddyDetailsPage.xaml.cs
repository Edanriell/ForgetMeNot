using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class BuddyDetailsPage : ContentPage
{
    public BuddyDetailsPage()
    {
        BindingContext = new BuddyDetailsViewModel();
        InitializeComponent();
    }
}
