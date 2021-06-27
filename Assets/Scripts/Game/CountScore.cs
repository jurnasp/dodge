using Dodge.Library.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Dodge.Game
{
    public class CountScore : MonoBehaviour
    {
        public Text highScoreText;
        public int Score { get; private set; }
        private const string EnemyTag = "Enemy";
        
        private LimitedQueue<int> _limitedQueue;
        private const int BufferSize = 20;

        private void Start()
        {
            _limitedQueue = new LimitedQueue<int>(BufferSize);
        }

        public void OnTriggerExit(Collider other)
        {
            var instanceID = GetParentInstanceID(other);
            if (!IsEnemy(other) || _limitedQueue.Contains(instanceID) || !UnderTrigger(other)) return;

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
    }
}
