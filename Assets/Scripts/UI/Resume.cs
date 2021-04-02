using UnityEngine;
using UnityEngine.SceneManagement;


public class Resume : MonoBehaviour
{
    public GameObject resumePanel;
    public GameObject pauseButton;
    public void PauseButtonPress()
    {
        Time.timeScale = 0;
        pauseButton.SetActive(false);
        resumePanel.SetActive(true);
    }
    public void ResumeButtonPress()
    {
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        resumePanel.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
