﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class Menu : MonoBehaviour
    {
        public GameObject trail;

        public GameObject statisticsMenu;
        public GameObject settingsMenu;
        public GameObject menuPanel;


        public Text totalTries;
        public Text totalScore;
        public Text highScore;
        public Text averageScore;

        public Text trails;
        public Text tutorial;
        public Text difficulty;


        public void Start()
        {
            var avrgScore = (float) PlayerPrefs.GetInt("TotalScore", 0) / PlayerPrefs.GetInt("TotalTries", 0);
            totalTries.text = "Tries : " + PlayerPrefs.GetInt("TotalTries", 0);
            totalScore.text = "Total score : " + PlayerPrefs.GetInt("TotalScore", 0);
            highScore.text = "High score : " + PlayerPrefs.GetInt("HighScoreEasy", 0) + ", " +
                             PlayerPrefs.GetInt("HighScoreNormal") + ", " + PlayerPrefs.GetInt("HighScoreHard");
            averageScore.text = "Average score : " + Math.Round(avrgScore, 2);

            if (PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
                difficulty.text = "EASY";
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
                difficulty.text = "MED";
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2) difficulty.text = "HARD";

            if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
                trails.text = "OFF";
            else if (PlayerPrefs.GetInt("TrailToggle", 0) == 0) trails.text = "ON";

            if (PlayerPrefs.GetInt("TutorialToggle", 0) == 1)
                tutorial.text = "ON";
            else if (PlayerPrefs.GetInt("TutorialToggle", 0) == 0) tutorial.text = "OFF";
        }

        public void ToGame() //kui vajutatakse "play" nuppu siis...{
        {
            SceneManager.LoadScene(1); //toob ette mängu "stseeni"
            PlayerPrefs.SetInt("TotalTries", PlayerPrefs.GetInt("TotalTries", 0) + 1); //lisab ühe kogumängude arvule}
        }

        public void ToStatistics() //kui vajutatakse "Stats" nuppu siis...{
        {
            menuPanel.SetActive(false); //kaotab menüü ekraani
            statisticsMenu.SetActive(true); //toob ette statistika ekraani}
        }

        public void BackToMenu() //kui vajutatakse "back" nuppu siis...
        {
            menuPanel.SetActive(true); //toob ette menüü
            statisticsMenu.SetActive(false); //kaotab satistika ekraani
            settingsMenu.SetActive(false); //kaotab sätte ekraani
        }

        public void ToSettings() //kui vajutatakse "settings" nuppu siis...
        {
            menuPanel.SetActive(false); //kaotab menüü
            settingsMenu.SetActive(true); //toob ette sätte ekraani
        }

        public void TrailsToggle() //kui "saba" on/off nuppu vajutada siis...
        {
            if (PlayerPrefs.GetInt("TrailToggle", 0) == 1) //kui enne oli tõene siis...
            {
                PlayerPrefs.SetInt("TrailToggle", 0); //nüüd muudeab selle valeks ja...
                trails.text = "ON"; //muudab nupu peal oleva kirja(ON/OFF) sättega tõeseks
                //trail.SetActive(true);    //!millegi pärast ei tööta siin vahetamine telefoni peal!
            } //(nt: Tõene siis näitab nupu peal "ON" kirja)
            else if (PlayerPrefs.GetInt("TrailToggle", 0) == 0) //kõik sama ainult vastupidi ülevalolevaga
            {
                PlayerPrefs.SetInt("TrailToggle", 1);
                trails.text = "OFF";
            }
        }

        public void TutorialToggle()
        {
            if (PlayerPrefs.GetInt("TutorialToggle", 0) == 1)
            {
                PlayerPrefs.SetInt("TutorialToggle", 0);
                tutorial.text = "OFF";
            }
            else if (PlayerPrefs.GetInt("TutorialToggle", 0) == 0)
            {
                PlayerPrefs.SetInt("TutorialToggle", 1);
                tutorial.text = "ON";
            }
        }

        public void DifficultyOption()
        {
            if (PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
            {
                PlayerPrefs.SetInt("DifficultyOption", 1);
                difficulty.text = "MED";
            }
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
            {
                PlayerPrefs.SetInt("DifficultyOption", 2);
                difficulty.text = "HARD";
            }
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
            {
                PlayerPrefs.SetInt("DifficultyOption", 0);
                difficulty.text = "EASY";
            }
        }
    }
}