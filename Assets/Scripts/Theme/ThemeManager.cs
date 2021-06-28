using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dodge.Theme
{
    public class ThemeManager : MonoBehaviour
    {
        public ThemeApplier themeApplier;

        public Theme currentTheme;

        private Dictionary<string, Theme> _themeDictionary;

        private string SelectedThemeName
        {
            get => PlayerPrefs.GetString("ThemeName", "Default");
            set => PlayerPrefs.SetString("ThemeName", value);
        }

        public void Start()
        {
            _themeDictionary = InitThemes();

            ApplyTheme("Blues");
        }

        private static Dictionary<string, Theme> InitThemes()
        {
            var themes = Resources.LoadAll<Theme>("Themes");
            return themes.ToDictionary(theme => theme.themeName);
        }

        public void ApplyTheme(string themeName)
        {
            SelectTheme(themeName);

            themeApplier.Apply(FindObjectsOfType<Themeable>(), currentTheme);
        }

        private void SelectTheme(string themeName)
        {
            if (!ThemeExists(themeName))
            {
                Debug.Log($"Theme \"{themeName}\" doesn't exist.");
                return;
            }

            if (!_themeDictionary[themeName].IsUnlocked())
            {
                Debug.Log($"Theme \"{themeName}\" not unlocked.");
                return;
            }

            SelectedThemeName = themeName;
            currentTheme = _themeDictionary[themeName];
        }

        public bool ThemeExists(string themeName)
        {
            return _themeDictionary.ContainsKey(themeName);
        }

        public void ApplyThemeToThemeable(Themeable themeableObject)
        {
            themeApplier.ApplyThemeToThemeable(themeableObject, currentTheme);
        }

        public string[] GetThemeNames()
        {
            return _themeDictionary.Keys.ToArray();
        }

        #region Singleton

        public static ThemeManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(gameObject);
            else
                Instance = this;
        }

        #endregion
    }
}