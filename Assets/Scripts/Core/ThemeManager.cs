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
            }
            else
            {
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

        public Camera camera;

        public void Start()
        {
            FindThemes();

            ApplyTheme("Blues");
        }

        public void ApplyTheme(string themeName)
        {
            SelectTheme(themeName);

            ApplyThemeToInstantiatedObjects();
            
            ApplyThemeToBackground();
        }

        private void FindThemes()
        {
            if (_themeDictionary.Count == 0)
            {
                var themes = Resources.LoadAll<Theme>("Themes");
                foreach (var theme in themes)
                {
                    _themeDictionary.Add(theme.themeName, theme);
                }
            }
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

        private void ApplyThemeToInstantiatedObjects()
        {
            var themeableObjects = FindObjectsOfType<Themeable>();
            foreach (var themeableObject in themeableObjects)
            {
                ApplyThemeToThemeable(themeableObject);
            }
        }

        public void ApplyThemeToThemeable(Themeable themeableObject)
        {
            var themeMaterial = currentTheme.FindMaterialWithName(themeableObject.GetMaterialName());
            if (themeMaterial != null)
            {
                themeableObject.SetMaterial(themeMaterial);
            }
        }

        private void ApplyThemeToBackground()
        {
            var themeMaterial = currentTheme.FindMaterialWithName("background");
            if (themeMaterial != null)
            {
                camera.backgroundColor = themeMaterial.color;
            }
        }

        public string[] GetThemeNames()
        {
            return _themeDictionary.Keys.ToArray();
        }
    }
}