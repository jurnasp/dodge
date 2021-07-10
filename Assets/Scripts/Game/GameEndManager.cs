using UnityEngine;
using UnityEngine.Events;

namespace Dodge.Game
{
    public class GameEndManager : MonoBehaviour
    {
        public UnityEvent gameEnd;

        [ContextMenu("Invoke game end")]
        public void GameEnd()
        {
            gameEnd.Invoke();
        }
    }
}