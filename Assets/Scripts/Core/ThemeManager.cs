using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dodge.Core
{
    public class ThemeManager : MonoBehaviour
    {
        #region Singleton
        private static ThemeManager _instance;

        public static ThemeManager Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            } else {
                _instance = this;
            }
        }
        #endregion
        
        public Theme currentTheme;

        private readonly Dictionary<string, Theme> _themeDictionary = new Dictionary<string, Theme>();
        
        private string SelectedThemeName
        {
            get => PlayerPrefs.GetString("ThemeName", "Default");
            set => PlayerPrefs.SetString("ThemeName", value);
        }

        public void Start()
        {
            var themes = Resources.LoadAll<Theme>("Themes");
            foreach (var theme in themes)
            {
                _themeDictionary.Add(theme.themeName, theme);
            }
            
            SelectTheme("Blues");

            LoadThemeToInstantiatedObjects();
        }

        public void LoadThemeToInstantiatedObjects()
        {
            var themeableObjects = FindObjectsOfType<Themeable>();
            foreach (var themeableObject in themeableObjects)
            {
                LoadThemeToThemeable(themeableObject);
            }
        }

        public void LoadThemeToThemeable(Themeable themeableObject)
        {
            var themeMaterial = currentTheme.FindMaterialWithName(themeableObject.GetMaterialName());
            if (themeMaterial != null)
            {
                themeableObject.SetMaterial(themeMaterial);
            }
        }

        public Theme[] GetThemes()
        {
            return _themeDictionary.Values.ToArray();
        }

        public string[] GetThemeNames()
        {
            return _themeDictionary.Keys.ToArray();
        }

        public void SelectTheme(string themeName)
        {
            if (!ThemeExists(themeName))
            {
                Debug.Log($"Theme \"{themeName}\" doesn't exist.");
                return;
            }
            SelectedThemeName = themeName;
            currentTheme = _themeDictionary[themeName];
        }

        public bool ThemeExists(string themeName)
        {
            return _themeDictionary.ContainsKey(themeName);
        }
    }
}
