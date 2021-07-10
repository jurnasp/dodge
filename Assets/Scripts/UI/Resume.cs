using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Resume : MonoBehaviour
    {
        public void PauseTime()
        {
            Time.timeScale = 0;
        }

        public void ResumeTime()
        {
            Time.timeScale = 1;
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(0);
            ResumeTime();
        }
    }
}