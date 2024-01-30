using CommunityToolkit.Mvvm.ComponentModel;

namespace ForgetMeNot.Models;

[ObservableObject]
public partial class Invitation
{
    [ObservableProperty]
    private string buddyCode = null!;

    [ObservableProperty]
    private int buddyId;
}
