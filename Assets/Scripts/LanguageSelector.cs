using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings; 

public class LanguageSelector : MonoBehaviour
{
    public void SelectorIdioma1()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];
    }
    public void SelectorIdioma2()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
    }
    public void SelectorIdioma3()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[2];
    }
}
