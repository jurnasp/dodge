using Dodge.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Dodge.UI
{
    public class ScoreAdd : MonoBehaviour
    {
        public GameObject left;
        public GameObject right;
        private LoseTrigger _leftMove;
        private LoseTrigger _rightMove;
        public Text scoreText;
        public Text highScoreText;
        public int score;
        public Text difficulty;

        public void Start()
        {
            if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
            {
                highScoreText.text = PlayerPrefs.GetInt("HighScoreEasy", 0).ToString();
                difficulty.text = "EASY";
            }
            else if(PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
            {
                highScoreText.text = PlayerPrefs.GetInt("HighScoreNormal", 0).ToString();
                difficulty.text = "MED";
            }
            else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
            {
                highScoreText.text = PlayerPrefs.GetInt("HighScoreHard", 0).ToString();
                difficulty.text = "HARD";
            }
            _leftMove = left.GetComponent<LoseTrigger>();
            _rightMove = right.GetComponent<LoseTrigger>();
        }
        public void ScoreRestart()          //kui vajutatakse "Retry" siis...{
        {
            score = 0;                          //skoor muudetakse tagasi 0 ja
            scoreText.text = score.ToString();  //see uuendatakse ekraanil}
        }

        public void OnTriggerEnter(Collider other)  //kui vastane möödub Right'ist ja Left'ist siis...{
        {
            if (_leftMove.lost | _rightMove.lost)         //kui mäng on kaotatud ja vastased mööduvad siis...{
            {
                return;                                     //ei lisa skoorile +1}
            }
            else if (!_leftMove.lost | !_rightMove.lost)                                  //aga kui mäng pole kaotatud siis...{
            {
                score++;                                                                    //lisab skoorile +1
                PlayerPrefs.SetInt("TotalScore", PlayerPrefs.GetInt("TotalScore", 0) + 1);  //lisab koguskoorile ühe otsa
                scoreText.text = score.ToString();                                          //uuendab seda ekraanil
                if(PlayerPrefs.GetInt("DifficultyOption", 0) == 0)
                {
                    if (PlayerPrefs.GetInt("HighScoreEasy", 0) < score)                             //kui kõrgeim skoor on väiksem kui praegune skoor siis...{
                    {
                        PlayerPrefs.SetInt("HighScoreEasy", score);                                     //asendab preaguse skoori vana kõrgeima skooriga
                        highScoreText.text = score.ToString();                                      //uuendab seda ekraanil}}
                    }
                }
                else if(PlayerPrefs.GetInt("DifficultyOption", 0) == 1)
                {
                    if (PlayerPrefs.GetInt("HighScoreNormal", 0) < score)
                    {
                        PlayerPrefs.SetInt("HighScoreNormal", score);
                        highScoreText.text = score.ToString();
                    }
                }
                else if (PlayerPrefs.GetInt("DifficultyOption", 0) == 2)
                {
                    if (PlayerPrefs.GetInt("HighScoreHard", 0) < score)
                    {
                        PlayerPrefs.SetInt("HighScoreHard", score);
                        highScoreText.text = score.ToString();
                    }
                }
            }
        }
    }
}
