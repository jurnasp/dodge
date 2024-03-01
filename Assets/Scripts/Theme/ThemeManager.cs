using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

namespace Theme
{
    public class ThemeManager : MonoBehaviour
    {
        public ThemeApplier themeApplier;
        public Dictionary<string, Theme> Themes => GetThemes();

        private Theme CurrentTheme
        {
            get
            {
                var themeName = PlayerConfig.GetCurrentTheme();
                if (!ThemeExists(themeName) || !Themes[themeName].IsUnlocked())
                    return Themes.Values.First();
                return Themes[themeName];
            }
            set => PlayerConfig.SetCurrentTheme(value.themeName);
        }

        private void Start()
        {
            SelectTheme(CurrentTheme);
        }

        private Dictionary<string, Theme> _cachedThemes;
        public Dictionary<string, Theme> GetThemes()
        {
            if (_cachedThemes == null)
            {
                var themes = Resources.LoadAll<Theme>("Themes");
                _cachedThemes = themes
                    .OrderByDescending(x => x.IsUnlocked())
                    .ThenBy(x => x.highScoreToUnlock)
                    .ToDictionary(theme => theme.themeName);
            }

            return _cachedThemes;
        }

        public List<Theme> GetSortedThemes()
        {
            var themeList = _cachedThemes.Values.ToList();
            themeList.Sort((x, y) => x.totalScoreToUnlock.CompareTo(y.totalScoreToUnlock));

            return themeList;
        }

        public void SelectTheme(Theme theme)
        {
            CurrentTheme = theme;

            themeApplier.Apply(FindObjectsOfType<Themeable>(), theme);
        }

        public bool ThemeExists(string themeName)
        {
            return Themes.ContainsKey(themeName);
        }

        public void ApplyThemeToThemeable(Themeable themeableObject)
        {
            themeApplier.ApplyThemeToThemeable(themeableObject, CurrentTheme);
        }

        public string[] GetThemeNames()
        {
            return Themes.Keys.ToArray();
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