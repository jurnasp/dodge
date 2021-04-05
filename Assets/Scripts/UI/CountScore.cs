using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CountScore : MonoBehaviour
    {
        public Text highScoreText;
        public int Score { get; private set; }
        
        private Stack<int> _bufferStack;
        private const int BufferSize = 20;

        private void Start()
        {
            _bufferStack = new Stack<int>(BufferSize);
        }

        public void OnTriggerExit(Collider other)
        {
            var instanceID = GetParentInstanceID(other);
            if (!IsEnemy(other) || _bufferStack.Contains(instanceID) || !UnderTrigger(other)) return;
            
            if (_bufferStack.Count > BufferSize - 1)
                _bufferStack.Pop();
                
            _bufferStack.Push(instanceID);

            Score++;
            highScoreText.text = Score.ToString();
        }

        private static bool IsEnemy(Collider other)
        {
            return other.CompareTag("Enemy");
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
