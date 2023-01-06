using System;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
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
            var avgScore = (float) PlayerConfig.GetTotalScore() / PlayerConfig.GetTotalGamesPlayed();

            totalTries.text = "Tries : " + PlayerConfig.GetTotalGamesPlayed();
            totalScore.text = "Total score : " + PlayerConfig.GetTotalScore();
            highScore.text = "High score : " + PlayerConfig.GetHighScore();
            averageScore.text = "Average score : " + RoundScore(avgScore);

            RefreshIsTrailEnabledButtonText();
            RefreshIsTutorialEnabledButtonText();
        }

        private static double RoundScore(float avgScore)
        {
            return Math.Round(avgScore, 2);
        }

        public void ToGame()
        {
            SceneManager.LoadScene(1);
        }

        public void TrailsToggle()
        {
            PlayerConfig.SetIsTrailEnabled(!PlayerConfig.GetIsTrailEnabled());

            RefreshIsTrailEnabledButtonText();
        }

        private void RefreshIsTrailEnabledButtonText()
        {
            trails.text = PlayerConfig.GetIsTrailEnabled() ? "OFF" : "ON";
        }

        public void TutorialToggle()
        {
            PlayerConfig.SetIsTutorialEnabled(!PlayerConfig.GetIsTutorialEnabled());

            RefreshIsTutorialEnabledButtonText();
        }

        private void RefreshIsTutorialEnabledButtonText()
        {
            tutorial.text = PlayerConfig.GetIsTutorialEnabled() ? "ON" : "OFF";
        }
    }
}
