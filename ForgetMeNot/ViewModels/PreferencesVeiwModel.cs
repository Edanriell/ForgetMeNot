using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ForgetMeNot.Models;
using ForgetMeNot.Services;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace ForgetMeNot.ViewModels;

[ObservableObject]
public partial class PreferencesViewModel
{
    [ObservableProperty]
    private List<Preference>? preferenceList;

    private IPreferenceService service;

    public PreferencesViewModel(IPreferenceService service)
    {
        this.service = service;
    }

    public async Task Init()
    {
        PreferenceList = await service.GetPreferences();
    }

    [RelayCommand]
    private async Task SavePreferencesAsync()
    {
        await service.Save(PreferenceList);
    }

    [RelayCommand]
    private async Task PreferencesSearch(object param)
    {
        var search = param.ToString();
    }
}
