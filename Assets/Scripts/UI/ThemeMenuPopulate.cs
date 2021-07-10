using Theme;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ThemeMenuPopulate : MonoBehaviour
    {
        public GameObject themeButton;
        public ThemeManager themeManager;

        private void Start()
        {
            Populate();
        }

        private void Populate()
        {
            var themes = themeManager.GetThemes();

            foreach (var theme in themes.Values)
            {
                var go = Instantiate(themeButton, transform, false);

                var tbp = go.GetComponentInChildren<ThemeButtonPopulate>();
                if (tbp != null) tbp.Setup(theme);

                go.GetComponentInChildren<Button>().onClick.AddListener(delegate
                {
                    themeManager.ApplyTheme(theme.themeName);
                });
            }
        }
    }
}