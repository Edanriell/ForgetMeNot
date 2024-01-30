using CommunityToolkit.Mvvm.ComponentModel;

namespace ForgetMeNot.Models;

[ObservableObject]
public partial class Preference
{
    [ObservableProperty]
    private string preferencePrompt = null!;

    [ObservableProperty]
    private string preferenceValue = null!;
}
