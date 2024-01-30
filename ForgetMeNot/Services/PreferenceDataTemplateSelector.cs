using ForgetMeNot.Models;

namespace ForgetMeNot.Services;

public class PreferenceDataTemplateSelector : DataTemplateSelector
{
    public DataTemplate PreferenceTemplate { get; set; } = null!;
    public DataTemplate PreferenceTemplateEmpty { get; set; } = null!;

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (((Preference)item)?.PreferenceValue == null)
            return PreferenceTemplateEmpty;
        return ((Preference)item).PreferenceValue.Length > 0
            ? PreferenceTemplate
            : PreferenceTemplateEmpty;
    }
}
