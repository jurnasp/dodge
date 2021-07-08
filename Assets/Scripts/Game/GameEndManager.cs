using UnityEngine;
using UnityEngine.Events;

namespace Dodge.Game
{
    public class GameEndManager : MonoBehaviour
    {
        public UnityEvent gameEnd;

        // private bool _hasGameEnded;

        [ContextMenu("Invoke game end")]
        public void GameEnd()
        {
            // if (_hasGameEnded) return;

            gameEnd.Invoke();
            // _hasGameEnded = true;
        }
    }
}