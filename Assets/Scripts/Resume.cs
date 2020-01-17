using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Resume : MonoBehaviour
{
    public GameObject resumePanel;
    public GameObject pauseButton;
    public void PauseButtonPress()  //kui pausi nuppu vajutatakse siis...
    {
        Time.timeScale = 0;             //muudab aja liikumise ühe pärismaailma sekundi jooksul 0, ehk midagi ei liigu
        pauseButton.SetActive(false);   //kaotab pausi nupu
        resumePanel.SetActive(true);    //toob ette menüü, kust saad valida kas tahad mängu alguses nähtud menüüsse("menu") või tahad mängu edasi mängida("resume")
    }
    public void ResumeButtonPress() //kui vajutatakse "resume" nuppu siis...
    {
        Time.timeScale = 1;             //muudab aja lugemise mängus samaks mis päriselus, ehk 1 mängu sekund möödub 1 päriselu sekundi jooksul
        pauseButton.SetActive(true);    //toob pausi nupu tagasi
        resumePanel.SetActive(false);   //kaotab pausi menüü
    }
    public void BackToMenu()        //kui vajutad pausi menüüs "menu" siis...
    {
        SceneManager.LoadScene(0);      //toob ette mängu alguse menüü
        Time.timeScale = 1;             //muudab aja lugemise samaks, milleks "ResumeButtonPress()" muudab
    }
}
