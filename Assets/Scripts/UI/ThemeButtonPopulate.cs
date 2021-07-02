using UnityEngine;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class ThemeButtonPopulate : MonoBehaviour
    {
        public void Setup(Theme.Theme theme)
        {
            gameObject.name = theme.themeName;
            
            var text = GetComponentInChildren<Text>();
            text.text = theme.themeName;
        }
    }
}
