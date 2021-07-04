using System.Collections.Generic;
using System.Linq;
using Dodge.Core;
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
            get => PlayerConfig.GetCurrentTheme();
            set => PlayerConfig.SetCurrentTheme(value);
        }

        private void Start()
        {
            _themeDictionary = GetThemes();
            
            ApplyTheme(SelectedThemeName);
        }

        public Dictionary<string, Theme> GetThemes()
        {
            if (_themeDictionary == null)
            {
                var themes = Resources.LoadAll<Theme>("Themes");
                _themeDictionary = themes.OrderBy(x => x.scoreToUnlock).ToDictionary(theme => theme.themeName);
            }

            return _themeDictionary;
        }

        public List<Theme> GetSortedThemes()
        {
            var themeList = _themeDictionary.Values.ToList();
            themeList.Sort((x, y) => x.scoreToUnlock.CompareTo(y.scoreToUnlock));
            
            return themeList;
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