using ForgetMeNot.ViewModels;

namespace ForgetMeNot.Pages;

public partial class MainPage : ContentPage
{
    private bool canBeSeen = true;

    private MainViewModel vm = new MainViewModel();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    public void OnImageTapped(Object sender, EventArgs e)
    {
        // BigFlowerImage.IsVisible = false;
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {
        canBeSeen = !canBeSeen;
        //BigFlowerImage.IsVisible = canBeSeen;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        vm.FullName = "UserName UserSurname";
        vm.FavoriteFlower = "flower.png";
    }
}
