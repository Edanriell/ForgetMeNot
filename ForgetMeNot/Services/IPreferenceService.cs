using ForgetMeNot.Models;

namespace ForgetMeNot.Services;

public interface IPreferenceService
{
    public Task<List<Preference>> GetPreferences();
    public Task Save(List<Preference> preferences);
}
