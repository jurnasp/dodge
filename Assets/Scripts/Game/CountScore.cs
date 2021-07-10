using Core;
using Library.Core;
using Library.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class CountScore : MonoBehaviour
    {
        private const string EnemyTag = Tag.Enemy;
        private const int BufferSize = 20;
        public Text highScoreText;
        private bool _gameEnd;

        private LimitedQueue<int> _limitedQueue;
        public int Score { get; private set; }

        private void Start()
        {
            _limitedQueue = new LimitedQueue<int>(BufferSize);
        }

        private void OnTriggerExit(Collider other)
        {
            var instanceID = GetParentInstanceID(other);
            if (_gameEnd || !IsEnemy(other) || _limitedQueue.Contains(instanceID) || !UnderTrigger(other)) return;

            _limitedQueue.Push(instanceID);

            Score++;
            highScoreText.text = Score.ToString();
        }

        private static bool IsEnemy(Collider other)
        {
            return other.CompareTag(EnemyTag);
        }

        private bool UnderTrigger(Collider other)
        {
            return other.transform.position.y < transform.position.y;
        }

        private int GetParentInstanceID(Component other)
        {
            var parent = other.transform.parent;
            var result = other.GetInstanceID();
            while (parent != null)
            {
                result = parent.GetInstanceID();

                parent = parent.parent;
            }

            return result;
        }

        public void StopCountingScore()
        {
            _gameEnd = true;
        }

        public void TryUpdateHighScore()
        {
            if (Score > PlayerConfig.GetHighScore())
                PlayerConfig.SetHighScore(Score);
        }

        public void AddScoreToTotalScore()
        {
            PlayerConfig.AddTotalScore(Score);
        }
    }
}