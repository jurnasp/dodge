using System;
using UnityEngine;

namespace Theme
{
    public class ThemeApplier : MonoBehaviour
    {
        private Camera Camera { get; set; }

        private void Awake()
        {
            Camera = Camera.main;
        }

        public void Apply(Themeable[] themeableObjects, Theme currentTheme)
        {
            ApplyThemeToInstantiatedObjects(themeableObjects, currentTheme);

            ApplyThemeToBackground(currentTheme);
        }

        private void ApplyThemeToInstantiatedObjects(Themeable[] themeableObjects, Theme currentTheme)
        {
            foreach (var themeableObject in themeableObjects) ApplyThemeToThemeable(themeableObject, currentTheme);
        }

        public void ApplyThemeToThemeable(Themeable themeableObject, Theme currentTheme)
        {
            var themeMaterial = currentTheme.FindMaterialWithName(themeableObject.GetCurrentMaterialName());
            if (themeMaterial != null) themeableObject.SetMaterial(themeMaterial);
        }

        private void ApplyThemeToBackground(Theme currentTheme)
        {
            var themeMaterial = currentTheme.FindMaterialWithName("background");
            if (themeMaterial != null) Camera.backgroundColor = themeMaterial.color;
        }
    }
}