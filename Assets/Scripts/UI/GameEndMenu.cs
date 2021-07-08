using Dodge.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class GameEndMenu : MonoBehaviour
    {
        public Text highScoreText;

        public void NewGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void RefreshHighScoreText()
        {
            highScoreText.text = PlayerConfig.GetHighScore().ToString();
        }
    }
}