using UnityEngine;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class ThemeButtonPopulate : MonoBehaviour
    {
        private Button _button;

        public void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void Setup(Theme.Theme theme)
        {
            SetGameObjectName(theme.themeName);

            SetTextContent(theme.themeName);

            if (!theme.IsUnlocked()) DisableButton();
        }

        private void SetGameObjectName(string themeName)
        {
            gameObject.name = themeName;
        }

        private void SetTextContent(string textContent)
        {
            var text = GetComponentInChildren<Text>();
            text.text = textContent;
        }

        private void DisableButton()
        {
            _button.interactable = false;
        }
    }
}