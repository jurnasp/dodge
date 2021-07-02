using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class Menu : MonoBehaviour
    {
        public Text totalTries;
        public Text totalScore;
        public Text highScore;
        public Text averageScore;

        public Text trails;
        public Text tutorial;


        public void Start()
        {
            var avgScore = (float) PlayerPrefs.GetInt("TotalScore", 0) / PlayerPrefs.GetInt("TotalTries", 0);
            totalTries.text = "Tries : " + PlayerPrefs.GetInt("TotalTries", 0);
            totalScore.text = "Total score : " + PlayerPrefs.GetInt("TotalScore", 0);
            highScore.text = "High score : " + PlayerPrefs.GetInt("HighScoreEasy", 0) + ", " +
                             PlayerPrefs.GetInt("HighScoreNormal") + ", " + PlayerPrefs.GetInt("HighScoreHard");
            averageScore.text = "Average score : " + Math.Round(avgScore, 2);

            if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
                trails.text = "OFF";
            else if (PlayerPrefs.GetInt("TrailToggle", 0) == 0) trails.text = "ON";

            if (PlayerPrefs.GetInt("TutorialToggle", 0) == 1)
                tutorial.text = "ON";
            else if (PlayerPrefs.GetInt("TutorialToggle", 0) == 0) tutorial.text = "OFF";
        }

        public void ToGame()
        {
            SceneManager.LoadScene(1);
        }

        public void TrailsToggle()
        {
            if (PlayerPrefs.GetInt("TrailToggle", 0) == 1)
            {
                PlayerPrefs.SetInt("TrailToggle", 0);
                trails.text = "ON";
            }
            else if (PlayerPrefs.GetInt("TrailToggle", 0) == 0)
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
    }
}