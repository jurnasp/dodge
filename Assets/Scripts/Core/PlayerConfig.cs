using UnityEngine;

namespace Core
{
    public class PlayerConfig : MonoBehaviour
    {
        #region TotalGamesPlayed

        public static void IncrementTotalGamesPlayed()
        {
            PlayerPrefs.SetInt("TotalTries", GetTotalGamesPlayed() + 1);
        }

        public static int GetTotalGamesPlayed()
        {
            return PlayerPrefs.GetInt("TotalTries", 0);
        }

        #endregion

        #region CurrentTheme

        public static void SetCurrentTheme(string value)
        {
            PlayerPrefs.SetString("ThemeName", value);
        }

        public static string GetCurrentTheme()
        {
            return PlayerPrefs.GetString("ThemeName", "Default");
        }

        #endregion

        #region IsTutorialEnabled

        public static void SetIsTutorialEnabled(bool enabled)
        {
            PlayerPrefs.SetInt("TutorialToggle", enabled ? 1 : 0);
        }

        public static bool GetIsTutorialEnabled()
        {
            return PlayerPrefs.GetInt("TutorialToggle", 0) == 1;
        }

        #endregion

        #region IsTrailEnabled

        public static void SetIsTrailEnabled(bool enabled)
        {
            PlayerPrefs.SetInt("TrailToggle", enabled ? 1 : 0);
        }

        public static bool GetIsTrailEnabled()
        {
            return PlayerPrefs.GetInt("TrailToggle", 0) == 1;
        }

        #endregion

        #region TotalScore

        public static void AddTotalScore(int score)
        {
            PlayerPrefs.SetInt("TotalScore", GetTotalScore() + score);
        }

        public static int GetTotalScore()
        {
            return PlayerPrefs.GetInt("TotalScore", 0);
        }

        #endregion

        #region HighScore

        public static void SetHighScore(int score)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        public static int GetHighScore()
        {
            return PlayerPrefs.GetInt("HighScore", 0);
        }

        #endregion
    }
}