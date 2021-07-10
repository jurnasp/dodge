using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameEndManager : MonoBehaviour
    {
        public UnityEvent gameEnd;

        private bool _hasGameEnded;

        [ContextMenu("Invoke game end")]
        public void GameEnd()
        {
            if (!_hasGameEnded)
            {
                gameEnd.Invoke();
                _hasGameEnded = true;
            }
        }
    }
}