using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject trail;

    public GameObject statisticsMenu;
    public GameObject settingsMenu;
    public GameObject MenuPanel;
    

    public Text totalTries;
    public Text totalScore;
    public Text highScore;
    public Text averageScore;

    public Text trails;
    public Text tutorial;
    public Text difficulty;

    public void ToGame()                                                        //kui vajutatakse "play" nuppu siis...{
    {
        SceneManager.LoadScene(1);                                                  //toob ette mängu "stseeni"
        PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0)+1);    //lisab ühe kogumängude arvule}
    }
    public void ToStatistics()          //kui vajutatakse "Stats" nuppu siis...{
    {
        MenuPanel.SetActive(false);         //kaotab menüü ekraani
        statisticsMenu.SetActive(true);     //toob ette statistika ekraani}
    }
    public void BackToMenu()            //kui vajutatakse "back" nuppu siis...
    {
        MenuPanel.SetActive(true);          //toob ette menüü
        statisticsMenu.SetActive(false);    //kaotab satistika ekraani
        settingsMenu.SetActive(false);      //kaotab sätte ekraani
    }
    public void ToSettings()            //kui vajutatakse "settings" nuppu siis...
    {
        MenuPanel.SetActive(false);         //kaotab menüü
        settingsMenu.SetActive(true);       //toob ette sätte ekraani
    }
    public void TrailsToggle()          //kui "saba" on/off nuppu vajutada siis...
    {
        if(PlayerPrefs.GetInt("TrailToggle", 0) == 1)           //kui enne oli tõene siis...
        {
            PlayerPrefs.SetInt("TrailToggle", 0);               //nüüd muudeab selle valeks ja...
            trails.text = "ON".ToString();                      //muudab nupu peal oleva kirja(ON/OFF) sättega tõeseks
            //trail.SetActive(true);    //!millegi pärast ei tööta siin vahetamine telefoni peal!
        }                                                               //(nt: Tõene siis näitab nupu peal "ON" kirja)
        else if(PlayerPrefs.GetInt("TrailToggle", 0) == 0)      //kõik sama ainult vastupidi ülevalolevaga
        {
            PlayerPrefs.SetInt("TrailToggle", 1);
            trails.text = "OFF".ToString();
        }
    }
    public void TutorialToggle()
    {
        if(PlayerPrefs.GetInt("TutorialToggle", 0) == 1)
        {
            PlayerPrefs.SetInt("TutorialToggle", 0);
            tutorial.text = "OFF".ToString();
        }
        else if(PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
        {
            PlayerPrefs.SetInt("TutorialToggle", 1);
            tutorial.text = "ON".ToString();
        }
    }
    public void DifficultyOption()
    {
        if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
        {
            PlayerPrefs.SetInt("DifficultyOption", 1);
            difficulty.text = "MED".ToString();
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
        {
            PlayerPrefs.SetInt("DifficultyOption", 2);
            difficulty.text = "HARD".ToString();
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
        {
            PlayerPrefs.SetInt("DifficultyOption", 0);
            difficulty.text = "EASY".ToString();
        }
    }


    public void Start()
    {
        float avrgScore = (float)PlayerPrefs.GetInt("TotalScore", 0) / PlayerPrefs.GetInt("TotalTries", 0);
        totalTries.text = "Tries : " + PlayerPrefs.GetInt("TotalTries", 0).ToString();
        totalScore.text = "Total score : " + PlayerPrefs.GetInt("TotalScore", 0).ToString();
        highScore.text = "High score : " + PlayerPrefs.GetInt("HighScoreEasy", 0).ToString() + ", " + PlayerPrefs.GetInt("HighScoreNormal").ToString() + ", " + PlayerPrefs.GetInt("HighScoreHard").ToString();
        averageScore.text = "Average score : " + System.Math.Round(avrgScore, 2).ToString();

        if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
        {
            difficulty.text = "EASY".ToString();
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
        {
            difficulty.text = "MED".ToString();
        }
        else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
        {
            difficulty.text = "HARD".ToString();
        }

        if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
        {
            trails.text = "OFF".ToString();
        }
        else if (PlayerPrefs.GetInt("TrailToggle", 0) == 0)
        {
            trails.text = "ON".ToString();
        }

        if(PlayerPrefs.GetInt("TutorialToggle", 0)== 1)
        {
            tutorial.text = "ON".ToString();
        }
        else if(PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
        {
            tutorial.text = "OFF".ToString();
        }
    }
}
